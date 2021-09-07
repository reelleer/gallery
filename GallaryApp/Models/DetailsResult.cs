using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallary.Models
{
    public class DetailsResult: CharacterDetails
    {
        public string Response { get; set; }

        public string Error { get; set; }
    }
}