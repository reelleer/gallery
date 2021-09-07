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
        SuperHeroService _superHeroService;
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
                searchResult = await Service.SearchAsync(query);
            }

            ViewBag.Query = query;

            return View(searchResult);
        }

        public async Task<ActionResult> About(int id)
        {
            var details = await Service.GetDetailsAsync(id);

            if(details.Response == "error")
            {
                return NotFound(Properties.Resources.CharacterIdNotFound);
            }

            if (Request.UrlReferrer?.Query != null)
            {
                var queries = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);

                ViewBag.Query = queries.Get("query") ?? "";
            }

            return View(details);
        }

        public ActionResult NotFound()
        {   
            return NotFound(Properties.Resources.NotFoundMessage);
        }

        private SuperHeroService Service
        {
            get {
                return _superHeroService ?? (_superHeroService = new SuperHeroService());
            }
        }

        private ActionResult NotFound(string message)
        {
            ViewBag.Message = message;

            Response.StatusCode = 404; //No found

            return View("_NotFound");
        }
    }
}