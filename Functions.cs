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
        public static bool processExist(string processName)
        {
            return Process.GetProcessesByName(processName).Length == 0 ? false : true;
        }
    }
}