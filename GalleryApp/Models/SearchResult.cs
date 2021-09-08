using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.Models
{
    public class SearchResult : IResult
    {
        public string Response { get; set; }

        public string Error { get; set; }

        [JsonProperty(PropertyName = "results-for")]
        public string ResultsFor { get; set; }

        public List<Character> Results { get; set; }
    }
}