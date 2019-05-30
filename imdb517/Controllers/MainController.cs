﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace imdb517.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        imdb521Entities8 db = new imdb521Entities8();
        public ActionResult Index()
        {
            List<viewAllMovies_Result> viewAllMovies_Results = db.viewAllMovies().ToList();
            db.SaveChanges();
            return View(viewAllMovies_Results);
        }
    }
}