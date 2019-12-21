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
        public static async Task<string> GetDataAsync(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await httpClient
                                                                .GetAsync(url);

                    return await httpResponse.Content.ReadAsStringAsync();
                }
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return string.Empty;
        }

        public static async Task<dynamic> AnonymousPostData(object data, string url)
        {
            try {
                
                return JsonConvert.DeserializeObject<dynamic>
                    (await PostDataAsync(JsonConvert.SerializeObject(data), url));
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            return null;
        }

        public static async Task<T> PostDataAsync<T>(object data, string url)
            where T:class,new()
        {
            try
            {
                return JsonConvert.DeserializeAnonymousType
                    (await PostDataAsync(JsonConvert.SerializeObject(data), url), new T());
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
