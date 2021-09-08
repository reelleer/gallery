using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlString Alert(
            this HtmlHelper helper,
            string message,
            AlertTypeEnum type = AlertTypeEnum.Info
        )
        {
            var icon = type.ToString().ToLower();

            var html = $"<div class=\"alert alert-{icon}\" role=\"alert\">" +
                $"<p class=\"h2\">&#12871{(int)type}; Got goose bumps!</p><p>" +
                $" <span class=\"text-capitalize\">{message}</span></p></div>";

            return new HtmlString(html);
        }
    }

    public enum AlertTypeEnum
    {
        Warning = 0,
        Danger,
        Info
    }
}