using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JustBanMeGUI
{
    public class Functions 
    {
        public const int status_READY = 0;
        public const int status_UNAVAILABLE = 1;
        public struct gameClass
        {
            public string gameName;
            public string shortName;
            public string processName;
            public bool isListed;
            public int status; /* 0: Ready
                                * 1: Unavailable
                                * */
        };
        public static bool processExist(string processName)
        {
            return Process.GetProcessesByName(processName).Length == 0 ? false : true;
        }
    }
}