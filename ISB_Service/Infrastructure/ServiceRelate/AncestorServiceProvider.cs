using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ISB_Service.Infrastructure
{
    abstract class AncestorServiceProvider
    {
        protected static string PostData(string json,string url)
        {
            using (HttpContent httpContent = new StringContent(json))
            {
                httpContent.Headers.ContentType = new System.Net
                            .Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpClient httpClient = new HttpClient())
                {
                    string result = httpClient.PostAsync(url, httpContent).Result
                                            .Content.ReadAsStringAsync().Result;

                    return result;
                }
            }
        }
    }
}
