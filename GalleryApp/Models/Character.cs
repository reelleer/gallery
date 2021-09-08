using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; }

        public Appearance Appearance { get; set; }

    }
    public struct Image
    {
        public string Url;
    }

    public struct Appearance
    {
        public string Gender { get; set; }

        public string Race { get; set; }

        public string[] Height { get; set; }

        public string[] Weight { get; set; }

        [JsonProperty("eye-color")]
        public string EyeColor { get; set; }
        
        [JsonProperty("hair-color")]
        public string HairColor { get; set; }
    }
}