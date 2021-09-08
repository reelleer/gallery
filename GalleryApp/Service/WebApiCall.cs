using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Gallery.Service
{
    public interface IWebApiCall
    {
        Task<string> GetContentAsync(string requestUri);
        Task<T> GetListItemsAsync<T>(string requestUri) where T : class, new();

        TimeSpan Timeout { get; set; }
    }

    public class WebApiCall : IWebApiCall
    {
        public WebApiCall()
        {
            Timeout = TimeSpan.FromSeconds(30);
        }

        public TimeSpan Timeout { get; set; }

        public virtual async Task<string> GetContentAsync(string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                HttpResponseMessage response;

                try
                {
                    response = await client.GetAsync(requestUri);
                }
                catch (HttpRequestException ex)
                {
                    var responde = new { response = "exception", error = ex.Message };

                    return JsonConvert.SerializeObject(responde);
                }
                catch (Exception ex)
                {
#if DEBUG
                    System.Diagnostics.Debug.WriteLine(
                        $"Execption.GetType = {ex.GetType()}"
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Execption.Messgae = {ex.Message}"
                    );
#endif
                    throw ex;
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
        public virtual async Task<T> GetListItemsAsync<T>(string requestUri) where T : class, new()
        {
            var content = await GetContentAsync(requestUri);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}