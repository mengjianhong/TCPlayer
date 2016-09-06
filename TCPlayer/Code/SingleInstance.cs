﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TCPlayer.Code
{
    //based on https://weblog.west-wind.com/posts/2016/May/13/Creating-Single-Instance-WPF-Applications-that-open-multiple-Files
    public class SingleInstanceApp
    {
        private static Mutex _mutex;
        private bool _isfirst;
        private string _UID;
        private const string EXIT_STRING = "__EXIT__";
        private Thread _server;
        private bool _isRunning = false;

        public event Action<string> ReceiveString;

        public SingleInstanceApp(string AppName)
        {
            _UID = GetUnique(AppName);
            _mutex = new Mutex(true, _UID, out _isfirst);
            _server = new Thread(ServerThread);
            _server.Start();
        }

        public bool IsFirstInstance
        {
            get { return _isfirst; }
        }

        public void Close()
        {
            _mutex.ReleaseMutex();
            _isRunning = false;
            Write(EXIT_STRING);
            Thread.Sleep(3); // give time for thread shutdown
        }

        private bool Write(string text, int connectTimeout = 300)
        {
            using (var client = new NamedPipeClientStream(_UID))
            {
                try { client.Connect(connectTimeout); }
                catch { return false; }

                if (!client.IsConnected) return false;

                using (StreamWriter writer = new StreamWriter(client))
                {
                    writer.Write(text);
                    writer.Flush();
                }
            }
            return true;
        }

        public void SubmitParameters()
        {
            var pars = Environment.GetCommandLineArgs();
            StringBuilder sb = new StringBuilder();
            for (int i=1; i<pars.Length; i++)
            {
                sb.AppendFormat("{0} ", pars[i]);
            }
            Write(sb.ToString());
        }

        private static string GetUnique(string AppName)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(AppName);
            var sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        private void ServerThread()
        {
            _isRunning = true;
            while (true)
            {
                string text;
                using (var server = new NamedPipeServerStream(_UID as string))
                {
                    server.WaitForConnection();

                    using (StreamReader reader = new StreamReader(server))
                    {
                        text = reader.ReadToEnd();
                    }
                }

                if (text == EXIT_STRING) break;

                ReceiveString?.Invoke(text);
                if (_isRunning == false) break;
            }
        }
    }
}
