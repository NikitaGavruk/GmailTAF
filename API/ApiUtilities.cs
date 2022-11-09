using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.API
{
    public class ApiUtilities
    {
        public static HttpWebResponse MakeRequest(HttpWebRequest request)
        {
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public static string GetBody(HttpWebResponse response)
        {
            string responceBody = String.Empty;

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    responceBody = r.ReadToEnd();
                }
            }
            return responceBody;
        }
        public static List<Root> DeserializeRootObject(string body) => JsonConvert.DeserializeObject<List<Root>>(body);
    }
}
