using Newtonsoft.Json;
using NLog;
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
        protected static readonly Logger FileLogger = LogManager.GetLogger("logFile");
        protected static readonly Logger DbLogger = LogManager.GetLogger("databaseLogger");

        protected static async Task<string> PostDataAsync(string json,string url)
        {
            try
            {
                using (HttpContent httpContent = new StringContent(json))
                {
                    httpContent.Headers.ContentType = new System.Net
                                .Http.Headers.MediaTypeHeaderValue("application/json");

                    using (HttpClient httpClient = new HttpClient())
                    {
                        HttpResponseMessage httpResponse = await httpClient.PostAsync(url, httpContent);

                        string result = await httpResponse.Content.ReadAsStringAsync();

                        return result;
                    }
                }
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return null;
        }
    }
}
