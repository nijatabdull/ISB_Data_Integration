using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Infrastructure
{
    class ServiceProvider : AncestorServiceProvider
    {
        private static readonly Logger FileLogger = LogManager.GetLogger("logFile");
        private static readonly Logger DbLogger = LogManager.GetLogger("databaseLogger");

        public static string GetData(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = httpClient
                            .GetAsync(url).Result;

                    return httpResponse.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return string.Empty;
        }

        public static dynamic AnonymousPostData(object data, string url)
        {
            try {
                
                return JsonConvert.DeserializeObject<dynamic>
                    (PostData(JsonConvert.SerializeObject(data), url));
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return null;
        }

        public static T PostData<T>(object data, string url)
            where T:class,new()
        {
            try
            {
                return JsonConvert.DeserializeAnonymousType
                    (PostData(JsonConvert.SerializeObject(data), url), new T());
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
