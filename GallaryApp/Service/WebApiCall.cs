using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Gallary.Service
{
    public class WebApiCall
    {
        public static async Task<string> GetContentAsync(string requestUri) 
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(2);

                HttpResponseMessage response;

                try
                {
                    response = await client.GetAsync(requestUri);
                }
                catch (Exception)
                {
                    throw;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = string.Format(
                        Properties.Resources.WebApiCallError,
                        response.StatusCode
                    );

                    throw new Exception(errorMessage);
                }

                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
        }
        public static async Task<T> GetListItemsAsync<T>(string requestUri) where T : class, new()
        {
            var content = await GetContentAsync(requestUri);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}