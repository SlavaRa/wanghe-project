using System;
using System.Collections.Generic;
using System.Text;

namespace LightingClick
{
    class AndSocketEventArgs:EventArgs
    {
        public string info;
        public AndSocketEventArgs(string str)
        {
            info = str;
        }
    }
}
