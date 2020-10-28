using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace JustBanMeGUI
{
    class Network
    {
        private const string url_endpoint = "https://api.vsolo.net/";
        private const string url_endpoint_sign = url_endpoint + "sign";
        private const string url_endpoint_update = url_endpoint + "update";

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

        public static void UpdateRoutine(string version)
        {
            var values = new Dictionary<string, string>
            {
                { "thisVersion", version }
            };
            var content = new FormUrlEncodedContent(values);
            var response =  client.PostAsync(url_endpoint_update, content).Result;
            string stringifiedResponse = response.Content.ReadAsStringAsync().Result;
            updateResponse Response = JsonConvert.DeserializeObject<updateResponse>(stringifiedResponse);
            if (Response.forceUpdate == true) // If update is not required
            {
                var downloadResponse = client.GetAsync(url_endpoint_update + "/" + Response.endPoint).Result;
                using (var stream = downloadResponse.Content.ReadAsStreamAsync().Result)
                {
                    var fileInfo = new FileInfo(Path.GetTempPath() + "GUIed.exe");
                    using (var fileStream = fileInfo.OpenWrite())
                    {
                        stream.CopyTo(fileStream);
                    }
                }
                var localFileName = System.AppDomain.CurrentDomain.FriendlyName;
                var path = System.AppDomain.CurrentDomain.BaseDirectory;

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c ping 127.0.0.1 -n 1 > nul & del " + path + localFileName + " & move " + Path.GetTempPath() + "GUIed.exe " + path + localFileName + " & start " + path + localFileName;
                process.StartInfo = startInfo;
                process.Start();

                Functions.terminateProgram();
            }
            else
            {
                return;
            }
        }
    }
}
