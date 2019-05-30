using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using imdb517.Models;

namespace imdb517.Controllers
{
    public class imdbController : Controller
    {
        imdb521Entities8 db = new imdb521Entities8();
        // GET: idmb
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllMovies()
        {
            List<viewAllMovies_Result> viewAllMovies_Results = db.viewAllMovies().ToList();
            List<newMovieList> newMovieLists = new List<newMovieList>();




            foreach (var x in viewAllMovies_Results)
            {

                newMovieList newMovieList = new newMovieList();

                if (newMovieLists.Where(p => p.movieid == x.movieid).Count() == 0)
                {
                    newMovieList.movieid = x.movieid;
                    newMovieList.id = x.id;
                    
                    newMovieList.Actor1 = viewAllMovies_Results.Where(a => a.movieid == x.movieid).Select(b => b.Actor1).ToList();
                    string actors = string.Join<string>(",", newMovieList.Actor1);
                    viewAllMovies_Results.Where(w => w.movieid == x.movieid).ToList().ForEach(s => s.Actor1 = actors);

                    newMovieLists.Add(newMovieList);
                }




            }


            
            viewAllMovies_Results = viewAllMovies_Results.GroupBy(t => t.movieid).Select(g => g.First()).ToList();




            return View(viewAllMovies_Results);
        }


        public ActionResult ViewAllProducers()
        {
            List<viewAllProducers_Result> viewAllProducers_Results = db.viewAllProducers().ToList();
            db.SaveChanges();
            return View(viewAllProducers_Results);
        }

        public ActionResult ViewAllActors()
        {
            List<viewAllActors_Result> viewAllProducers_Results = db.viewAllActors().ToList();
            db.SaveChanges();
            return View(viewAllProducers_Results);
        }

        public ActionResult ViewMovie(int id)
        {
            List<moviedetails_Result> moviedetails_Results = db.moviedetails(id).ToList();
            


            return View(moviedetails_Results);
        }

        public ActionResult ViewProducerMovies(int id)
        {
            List<producerMovies_Result> producerMovies_Results = db.producerMovies(id).ToList();
            db.SaveChanges();
            return View(producerMovies_Results);
        }

        public ActionResult ViewActorMovies(int id)
        {
            List<actorMovies_Result> actorMovies = db.actorMovies(id).ToList();
            db.SaveChanges();
            return View(actorMovies);
        }

        public ActionResult AllMoviesByProducers(string id)
        {
            List<viewMoviebyProducer_Result> producer_Results = db.viewMoviebyProducer(id).ToList();
            TempData["ProdName"] = id;
            return View(producer_Results);
        }

        public ActionResult AllMoviesByActor(string id)
        {
            List<viewMoviebyActor_Result> producer_Results = db.viewMoviebyActor(id).ToList();
            TempData["ActorName"] = id;
            return View(producer_Results);
        }


        public ActionResult AddMovies()
        {
            multi movies = new multi();


            ViewBag.producerid = new SelectList(db.Producers.OrderBy(m=>m.ProducersName), "Id", "ProducersName");
            ViewBag.Actorid0 = new SelectList(db.updatedActors.OrderBy(m=>m.Actor1), "Id", "Actor1");

            return View(movies);
        }

        [HttpPost]
        public ActionResult AddMovies(multi movies, FormCollection formCollection)
        {
            string newProducerCheck = formCollection["ProducersName"].Trim();
            string newActorCheck = formCollection["Actor1"].Trim();
            string actor = formCollection["Actorid0"];
            List<int> allactors = actor.Split(',').Select(int.Parse).ToList();


            if (newProducerCheck !=null  && newProducerCheck != "")
            {
                movies.producerid = ViewBag.producerid = new SelectList(db.Producers, "Id", "ProducersName").Count();
            }
            if (newActorCheck != null && newActorCheck != "")
            {
                movies.Actorid = ViewBag.Actorid = new SelectList(db.updatedActors, "Id", "Actor1").Count();
            }

            if (ModelState.ContainsKey("{producerid}"))
                ModelState["{producerid}"].Errors.Clear();

            if (ModelState.IsValid)
            {
              
                int res = db.AddMovies(movies.MoviesName, movies.YearOfRelease, movies.Plot, movies.producerid,movies.image);
                this.db.SaveChanges();
                var movieid = db.Movies.SqlQuery("select  * from movies where MoviesName= " + "'" + movies.MoviesName + "'").FirstOrDefault();

                foreach(var act in allactors)
                {
                   db.addactorandmovie(movieid.Id, act);
                   this.db.SaveChanges();
                }
                TempData["Message"] = movies.MoviesName+ "   Movie Added Successfully!";
                

            }
            
            
           

            ViewBag.producerid = new SelectList(db.Producers, "Id", "ProducersName", movies.producerid);
            ViewBag.Actorid = new SelectList(db.updatedActors, "Id", "Actor1", movies.Actorid);
            return RedirectToAction("ViewAllMovies");
        }

        public ActionResult addwithprod()
        {
            
            return View();
        }
        [HttpPost]
        public ContentResult addwithprod(multi movies,FormCollection formCollection)
        {
            

          
                string ProducerName = formCollection["ProducersName"];
                string Sex = gender(formCollection["Sex"]);
                string DOB = formCollection["DOB"];
                string BIO = formCollection["Bio"];

                if (ProducerName != "" && Sex != "" && BIO != "")
                {
                    db.addProducers(ProducerName, Sex, DOB, BIO);
                    ViewBag.producerid = new SelectList(db.Producers, "Id", "ProducersName");
                    return Content(ProducerName);
                }
                else
                {
                    return Content("Something went wrong");
                }
            
                
            
          
            
           
        }

        public ActionResult addwithactor()
        {

            return View();
        }
        [HttpPost]
        public ContentResult addwithactor(multi movies, FormCollection formCollection)
        {
            string ActorName = formCollection["Actor1"].Trim();
            string Sex =gender(formCollection["Actor1Sex"]).Trim();
            string DOB = formCollection["Actor1DOB"];
            string BIO = formCollection["Actor1Bio"].Trim();

            if ( ActorName != "" && Sex != "" && BIO != "")
            {
                db.addActors(ActorName, Sex, DOB, BIO);
                
                return Content(ActorName);
            }
            else
            {
                return Content("Something went wrong");
            }


           
        }
        public ActionResult EditMovies(int id)
        {
            
           
            Producers producers = new Producers();
           

            prefilledEdit_Result prefilledEdit_Result = new prefilledEdit_Result();
            prefilledEdit_Result = db.prefilledEdit(id).FirstOrDefault();
            ViewBag.totalActor = db.totalActors(id).FirstOrDefault();

            TempData["editMovie"] = prefilledEdit_Result.MoviesName;

            
            ViewBag.producerid = new SelectList(db.Producers.OrderBy(m => m.ProducersName), "Id", "ProducersName");
            ViewBag.Actorid1 = new SelectList(db.updatedActors.OrderBy(m => m.Actor1), "Id", "Actor1");
            ViewBag.Actorid2 = new SelectList(db.updatedActors.OrderBy(m => m.Actor1), "Id", "Actor1");
            ViewBag.Actorid3 = new SelectList(db.updatedActors.OrderBy(m => m.Actor1), "Id", "Actor1");
            ViewBag.Actorid4 = new SelectList(db.updatedActors.OrderBy(m => m.Actor1), "Id", "Actor1");
            return View(prefilledEdit_Result);

        }

        [HttpPost]

        public ActionResult EditMovies(Movies movies, FormCollection formCollection)
        {

           
            
            if (ModelState.IsValid)
            {
                var res = db.editMovies(movies.Id, movies.MoviesName,movies.YearOfRelease, movies.Plot, movies.producerid,movies.imageUrl);
                string actor1 = formCollection["Actorid1"];
                string actor2 = formCollection["Actorid2"];
                string actor3 = formCollection["Actorid3"];
                string actor4 = formCollection["Actorid4"];
                var ac = db.actorMovie.Where(t => t.movieid == movies.Id).Select(b => b.id).ToList();
               
                
                if (actor1 != null)
                {

                    int actorid =Convert.ToInt16(actor1);
                    int id = ac.ElementAt(0);
                    db.editActorInMovie(actorid, id);
                }
                
                
                if (actor2 != null)
                {
                    int actorid = Convert.ToInt16(actor2);
                    int id = ac.ElementAt(1);
                    db.editActorInMovie(actorid, id);
                }
                
                
                if (actor3 != null)
                {
                    int actorid = Convert.ToInt16(actor3);
                    int id= ac.ElementAt(2);
                    db.editActorInMovie(actorid, id);
                }
                
                
                if (actor4 != null)
                {
                    int actorid = Convert.ToInt16(actor3);
                    int id  = ac.ElementAt(2);
                    db.editActorInMovie(actorid, id);
                }



                ac.Clear();
                this.db.SaveChanges();
            }

            return RedirectToAction("ViewAllMovies");
        }


        public ActionResult addActors()
        {
            updatedActors actors = new updatedActors();
            return View(actors);
        }


        [HttpPost]

        public ActionResult addActors(updatedActors actors, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string strDDLValue = form["Sex"].ToString();
                strDDLValue = gender(strDDLValue);
                int res = db.addActors(actors.Actor1, strDDLValue, actors.DOB, actors.Bio);
                this.db.SaveChanges();
                Thread.Sleep(3000);
            }
            return RedirectToAction("ViewAllActors");

        }


        public ActionResult addProcuders()
        {
            Producers producers = new Producers();
            return View(producers);
        }


        [HttpPost]

        public ActionResult addProcuders(Producers producers, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string strDDLValue = form["Sex"].ToString();
                strDDLValue = gender(strDDLValue);
                int res = db.addProducers(producers.ProducersName, strDDLValue, producers.DOB, producers.Bio);
                this.db.SaveChanges();
                Thread.Sleep(3000);
            }

            return RedirectToAction("ViewAllProducers");
        }

        public ActionResult Delete(int id)
        {
            prefilledEdit_Result prefilledEdit_Result = new prefilledEdit_Result();
            prefilledEdit_Result = db.prefilledEdit(id).FirstOrDefault();
            
            return View(prefilledEdit_Result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfrimed(int id)
        {
            db.deleteMovies(id);
            db.SaveChanges();
            Thread.Sleep(3000);
            return RedirectToAction("Index", "Home");
        }

        public string gender(string sex)
        {
            if (sex == "1")
            {
                return "Male";
            }
            else if (sex == "2")
            {
                return "Female";
            }
            else
            {
                return "Others";
            }

        }
    }
}