using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallary.Models
{
    public class CharacterDetails: Character
    {
        public Powerstats Powerstats { get; set; }

        public Biography Biography { get; set; }

        public Work Work { get; set; }

        public Connections Connections { get; set; }
    }

    public struct Powerstats
    {
        public string Intelligence { get; set; }

        public string Strength { get; set; }

        public string Speed { get; set; }

        public string Durability { get; set; }

        public string Power { get; set; }

        public string Combat { get; set; }
    }

    public struct Biography
    {
        [JsonProperty("full-name")]
        public String FullName { get; set; }

        [JsonProperty("alter-egos")]
        public string AlterEgos { get; set; }

        public string[] Aliases { get; set; }

        [JsonProperty("place-of-birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("first-appearance")]
        public string FirstAppearance { get; set; }

        public string Publisher { get; set; }

        public string Alignment { get; set; }
    }

    public struct Work
    {
        public string Occupation { get; set; }

        public string Base { get; set; }
    }

    public struct Connections
    {
        [JsonProperty("group-affiliation")]
        public string GorupAffiliation { get; set; }

        public string Relatives { get; set; }
    }
}