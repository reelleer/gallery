using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallary.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; }


    }
    public struct Image
    {
        public string Url;
    }
}