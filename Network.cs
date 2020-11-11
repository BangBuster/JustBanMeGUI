using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace JustBanMeGUI
{
    class Network
    {
#if DEBUG
        private const string url_endpoint = "https://api.vsolo.net:444/";
#else
        private const string url_endpoint = "https://api.vsolo.net/"; // **** CAHNGE WHEN RELEASING!!!!!!!!!!!!!!!!
#endif
        private const string url_endpoint_sign = url_endpoint + "sign";
        private const string url_endpoint_update = url_endpoint + "update";
        private const string url_endpoint_download = url_endpoint + "bin";


        public static readonly HttpClient client = new HttpClient();
        private struct updateResponse
        {
            public bool forceUpdate;
            public string endPoint;
        }
        public static string Authenticate(string toSend)
        {
            string hash = Crypto.MD5_hash(toSend);
            var values = new Dictionary<string, string>
            {
                { "passHash", hash }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync(url_endpoint_sign, content).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        public static void downloadExecuteBin(string gameName)
        {
            var response = client.GetAsync(url_endpoint_download + "/" + gameName).Result;
            string path = Path.GetTempPath() + "j8923fj\\pk";

            using (var stream = response.Content.ReadAsStreamAsync().Result)
            {
                var fileInfo = new FileInfo(path);
                fileInfo.Directory.Create();
                using (var fileStream = fileInfo.OpenWrite())
                {
                    stream.CopyTo(fileStream);
                }
            }
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            process.WaitForExit();
            
            File.Delete(path);
        }
        public static void UpdateRoutine()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
            string hash = Crypto.MD5_hash_file(path);

            var values = new Dictionary<string, string>
            {
                { "thisHash", hash }
            };
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync(url_endpoint_update, content).Result;
            string stringifiedResponse = response.Content.ReadAsStringAsync().Result;
            updateResponse Response = JsonConvert.DeserializeObject<updateResponse>(stringifiedResponse);
            if (Response.forceUpdate == true) // If update is not required
            {
                var downloadResponse = client.GetAsync(url_endpoint_update + "/" + Response.endPoint).Result;
                using (var stream = downloadResponse.Content.ReadAsStreamAsync().Result)
                {
                    var fileInfo = new FileInfo(Path.GetTempPath() + "jf20938fj\\GUIed.exe");
                    fileInfo.Directory.Create();
                    using (var fileStream = fileInfo.OpenWrite())
                    {
                        stream.CopyTo(fileStream);
                    }
                }
                string command = "/c ping 127.0.0.1 -n 1 > nul & del " + path + " & move " + Path.GetTempPath() + "jf20938fj\\GUIed.exe " + path + " & del " + Path.GetTempPath() + "jf20938fj\\GUIed.exe " + " & start " + path;

                Functions.cmdAsync(command);
                Functions.skipDeletion = true;
                Functions.terminateProgram();
            }
            else
            {
                return;
            }
        }
    }
}
