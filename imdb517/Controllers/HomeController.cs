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
            try
            {
                List<allmovieswithImage_Result> viewAllMovies_Results = db.allmovieswithImage().ToList();
                viewAllMovies_Results = viewAllMovies_Results.GroupBy(t => t.MoviesName).Select(g => g.First()).ToList();

                return View(viewAllMovies_Results);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public ActionResult About()
        {
            try
            {
                ViewBag.Message = "What is IMDb?";

                return View();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult Contact()
        {
            try
            {
                ViewBag.Message = "";

                return View();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }  
}