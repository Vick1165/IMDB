using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace imdb517.Models
{
    public class newMovieList
    {
        public int movieid { get; set; }
        public int id { get; set; }
        public string MoviesName { get; set; }
        public string YearOfRelease { get; set; }
        public string plot { get; set; }
        public List<string> Actor1 { get; set; }
        public string ProducersName { get; set; }
    }
}