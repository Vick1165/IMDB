using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace imdb517.Models
{
    public class editMovies
    {

        public int Id { get; set; }
        public string MoviesName { get; set; }
        public string YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int producerid { get; set; }
        public int Actorid { get; set; }

        public virtual updatedActors updatedActors { get; set; }
        public virtual Producers Producers { get; set; }
    }
}