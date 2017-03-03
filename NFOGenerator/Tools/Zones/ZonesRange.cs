﻿/// Copyright 2017 Jevenski C. Woodsmann. All Rights Reserved
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
///     http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator.Tools.Zones
{
    class ZonesRange
    {
        public string rangeStart { get; set; }
        public string rangeEnd { get; set; }
        public ZoneMode rangeMode;
        public double rangePara { get; set; }

        public ZonesRange(string start, string end, ZoneMode mode, double para)
        {
            this.rangeStart = start;
            this.rangeEnd = end;
            this.rangeMode = mode;
            this.rangePara = para;
        }

        public string GetRangeCommand()
        {
            string command = this.rangeStart + "," + this.rangeEnd + "," + this.rangeMode.ToString() + 
                "=" + this.rangePara.ToString();
            return command;
        }
    }

    public enum ZoneMode
    {
        crf = 0,
        b = 1
    }
}
