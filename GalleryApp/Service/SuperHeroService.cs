using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Gallery.Service
{
    public class SuperHeroService
    {
        readonly string _baseUri;
        readonly IWebApiCall _webApiCall;

        public SuperHeroService() :
            this(
                Properties.Settings.Default.SUPER_HERO_API_BASE_URI,
                new WebApiCall()
            )
        { }

        public SuperHeroService(string baseUri, IWebApiCall webApiCall)
        {
            _baseUri = baseUri.EndsWith("/") ? baseUri : baseUri + "/";
            _webApiCall = webApiCall;
        }

        public async Task<SearchResult> SearchAsync(string name)
        {
            var uri = $"{_baseUri}search/{name}";

            var result = await _webApiCall.GetListItemsAsync<SearchResult>(uri);

#if DEBUG
            System.Diagnostics.Debug.WriteLine(
                $"SearchResult.Response = {result.Response}"
            );

            System.Diagnostics.Debug.WriteLine(
                $"SearchResult.Response.Result = {result.Results?.Count ?? 0}"
            );
#endif      

            return result;
        }

        public async Task<DetailsResult> GetDetailsAsync(int id)
        {
            var uri = $"{_baseUri}{id}";

            var result = await _webApiCall.GetListItemsAsync<DetailsResult>(uri);

            return result;
        }

        public async void Test()
        {
            var content = await _webApiCall.GetContentAsync($"{_baseUri}664");

            System.Diagnostics.Debug.WriteLine(content);
        }
    }
}