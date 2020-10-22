using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JustBanMeGUI
{
    class Network
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<string> Authenticate(string toSend)
        {
            const string url_endpoint = "https://api.vsolo.net/sign";
            string hash = Crypto.MD5_hash(toSend);
            var values = new Dictionary<string, string>
            {
                { "passHash", hash }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url_endpoint, content);
            return await response.Content.ReadAsStringAsync();
        }



    }
}
