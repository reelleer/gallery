using Gallary.Models;
using Gallary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gallary.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(string query)
        {
            SearchResult searchResult;

            if (string.IsNullOrWhiteSpace(query))
                searchResult = new SearchResult()
                {
                    Response = "surcess"
                };
            else
            {
                var superHeroService = new SuperHeroService();
                searchResult = await superHeroService.SearchAsync(query);
            }

            return View(searchResult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}