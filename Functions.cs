using System;
using System.Diagnostics;
using System.IO;
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
    public class Constants
    {
        public const int status_READY = 0;
        public const int status_UNAVAILABLE = 1;
        public const int THREADSLEEP = 500;
    }
    public class Functions
    {
        public struct SuccessJson
        {
            public string session;
            public gameClass[] games;
        }
        public static SuccessJson GamesJson;
        public static returnType invokeFunction<returnType>(IntPtr libraryAddress, UInt32 functionOrdinal, Type Delegate) 
        { // ex: int a = Functions.invokeFunction<int>(lib, 1, typeof(Functions.f_print));

            IntPtr functionPointer = nativeFunctions.GetProcAddress(libraryAddress, functionOrdinal);
        return (returnType)Marshal.GetDelegateForFunctionPointer(nativeFunctions.GetProcAddress(libraryAddress, functionOrdinal), Delegate).DynamicInvoke();
    }
        public static string reverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static bool skipDeletion = false;
        public static void terminateProgram() // Terminates running process
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }
        public static void cmd(string command)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
        public static void cmdAsync(string command)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();
        }
        public static returnType invokeFunction<returnType>(IntPtr libraryAddress, string funcitonName, Type Delegate) 
            { // ex: int a = Functions.invokeFunction<int>(lib, 1, typeof(Functions.f_print));
                IntPtr functionPointer = nativeFunctions.GetProcAddress(libraryAddress, funcitonName);
            return (returnType)Marshal.GetDelegateForFunctionPointer(nativeFunctions.GetProcAddress(libraryAddress, funcitonName), Delegate).DynamicInvoke();
        }
            public delegate void f_genericVoid();
            public delegate int f_print();
            public struct gameClass
            {
                public string gameName;
                public string shortName;
                public string processName;
                public int status; /* 0: Ready
                                    * 1: Unavailable
                                    * */
            };
            public static bool processExist(string processName)
            {
                return Process.GetProcessesByName(processName).Length == 0 ? false : true;
            }
        }
        public class Crypto
        {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string SHA1_hash(string toHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.ASCII.GetBytes(toHash))).Replace("-", string.Empty);
            }
        }
        public static string MD5_hash(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static string MD5_hash_file(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        public static string hardcoded_xor_key = "jfo3whywo34iuhko3w4o";
        public static string XOR_EncryptDecrypt(string text, string key)
        {
            var result = new StringBuilder();
            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));
            return result.ToString();
        }
    }
}