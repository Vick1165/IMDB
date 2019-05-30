using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace imdb517.Controllers
{
    public class HomeController : Controller
    {
        imdbfinalEntities db = new imdbfinalEntities();
        public ActionResult Index()
        {
            List<allmovieswithImage_Result> viewAllMovies_Results = db.allmovieswithImage().ToList();
            viewAllMovies_Results = viewAllMovies_Results.GroupBy(t => t.MoviesName).Select(g => g.First()).ToList();

            return View(viewAllMovies_Results);
        }
        public ActionResult About()
        {
            ViewBag.Message = "What is IMDb?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }  
}