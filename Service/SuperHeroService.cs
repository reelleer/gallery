using Gallary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Gallary.Service
{
    public class SuperHeroService
    {
        readonly string _baseUri;

        public SuperHeroService() :
            this(Properties.Settings.Default.SUPER_HERO_API_BASE_URI)
        { }

        public SuperHeroService(string baseUri)
        {
            _baseUri = baseUri.EndsWith("/") ? baseUri : baseUri + "/";
        }

        public async Task<SearchResult> SearchAsync(string name)
        {
            var uri = $"{_baseUri}search/{name}";

            var result = await WebApiCall.GetListItemsAsync<SearchResult>(uri);

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

        public async void Test()
        {
            var content = await WebApiCall.GetContentAsync($"{_baseUri}664");

            System.Diagnostics.Debug.WriteLine(content);
        }
    }
}