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
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TCPlayer.Code
{
    [Serializable]
    [XmlType(TypeName = "bookmark")]
    public class RadioStation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }
    }

    [Serializable]
    [XmlType(TypeName = "group")]
    public class RadioGroup
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("bookmark")]
        public List<RadioStation> Stations { get; set; }

        [XmlElement("group")]
        public List<RadioGroup> SubGroups { get; set; }
    }
}
