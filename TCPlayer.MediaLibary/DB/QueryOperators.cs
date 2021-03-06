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
using System.ComponentModel.DataAnnotations;

namespace TCPlayer.MediaLibary.DB
{
    public enum QueryOperator : int
    {
        [Display(Name ="")]
        NotSet = -1,
        [Display(Name = "=")]
        Equals = 0,
        [Display(Name = "<")]
        Less = 1,
        [Display(Name = "<=")]
        LessOrEqual = 2,
        [Display(Name = ">")]
        Greater = 3,
        [Display(Name = ">=")]
        GreaterOrEqual = 4
    }

    public enum StringOperator: int
    {
        [Display(Name = "Contains, Ignore Case")]
        ContainsIgnoreCase = 0,
        [Display(Name = "Contains")]
        Contains = 1,
        [Display(Name = "Exact Match, Ignore Case")]
        ExactmatchIgnoreCase = 2,
        [Display(Name = "Exact Match")]
        Exactmatch = 3
    }
}
