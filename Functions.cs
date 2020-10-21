using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace JustBanMeGUI
{
    using System;
    using System.Runtime.InteropServices;
    public class nativeFunctions
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string path);
        
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, uint ordinal);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string functionName);
    }
    public class Functions
    {
    public static returnType invokeFunction<returnType>(IntPtr libraryAddress, UInt32 functionOrdinal, Type Delegate) 
        { // ex: int a = Functions.invokeFunction<int>(lib, 1, typeof(Functions.f_print));

            IntPtr functionPointer = nativeFunctions.GetProcAddress(libraryAddress, functionOrdinal);
        return (returnType)Marshal.GetDelegateForFunctionPointer(nativeFunctions.GetProcAddress(libraryAddress, functionOrdinal), Delegate).DynamicInvoke();
    }
    public static returnType invokeFunction<returnType>(IntPtr libraryAddress, string funcitonName, Type Delegate) 
        { // ex: int a = Functions.invokeFunction<int>(lib, 1, typeof(Functions.f_print));
            IntPtr functionPointer = nativeFunctions.GetProcAddress(libraryAddress, funcitonName);
        return (returnType)Marshal.GetDelegateForFunctionPointer(nativeFunctions.GetProcAddress(libraryAddress, funcitonName), Delegate).DynamicInvoke();
    }

        public delegate void f_genericVoid();
        public delegate int f_print();

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
        public static string sha1_hash(string toHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.ASCII.GetBytes(toHash))).Replace("-", string.Empty);
            }
        }

    }
}