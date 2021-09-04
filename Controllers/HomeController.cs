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
        public async Task<ActionResult> Index(string name)
        {

            var superHeroService = new SuperHeroService();
            var searchResult = await superHeroService.Search(
                string.IsNullOrWhiteSpace(name) ?
                    Properties.Settings.Default.DEFAULT_NAME :
                    name
            );

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