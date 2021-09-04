using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallary.Models
{
    public class SearchResult
    {
        public string Response { get; set; }

        [JsonProperty(PropertyName = "results-for")]
        public string ResultsFor { get; set; }

        public List<Hero> Results { get; set; }
    }
}