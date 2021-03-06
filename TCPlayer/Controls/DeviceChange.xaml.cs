﻿/*
    TC Plyer
    Total Commander Audio Player plugin & standalone player written in C#, based on bass.dll components
    Copyright (C) 2016 Webmaster442 aka. Ruzsinszki Gábor

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using TCPlayer.Code;
using System;
using System.Windows.Controls;

namespace TCPlayer.Controls
{
    /// <summary>
    /// Interaction logic for DeviceChange.xaml
    /// </summary>
    public partial class DeviceChange : UserControl, IDialog
    {
        public DeviceChange()
        {
            InitializeComponent();
        }

        public Action OkClicked
        {
            get; set;
        }

        public int DeviceIndex
        {
            get { return LbDevices.SelectedIndex; }
        }

        public int SampleRate
        {
            get
            {
                var item = CbSampleRate.SelectedItem as ComboBoxItem;
                return Convert.ToInt32(item.Content);
            }
        }
    }
}
