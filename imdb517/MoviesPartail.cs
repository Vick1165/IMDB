using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace imdb517
{
    //[MetadataType(typeof(UpdatedMovies))]
    //public partial class Movies
    //{

    //}
    //public class UpdatedMovies
    //{
    //    [Required(ErrorMessage = "Name is Requirde")]
    //    [DisplayName("Movie Name")]
    //    public string MovieName { get; set; }

    //    [Required(ErrorMessage = "Year is Requirde")]
    //    [DisplayName("Year")]
    //    public string YearOfRelease { get; set; }
    //    [Required(ErrorMessage = "Plot is Requirde")]
    //    [DisplayName("Plot")]
    //    public string Plot { get; set; }

    //    [DisplayName("Producer")]
    //    public int producerid { get; set; }

    //    [DisplayName("Actor")]
    //    public int Actorid { get; set; }
    //}

    [MetadataType(typeof(prefilledEdit_ResultUpdate))]
    public partial class prefilledEdit_Result
    {
        [DisplayName("Actors")]
        public string Actorid { get; set; }
    }

    public class prefilledEdit_ResultUpdate
    {
        [Required(ErrorMessage = "Please Enter Movie Name")]
        [DisplayName("Movie")]
        public string MoviesName { get; set; }

        [Required(ErrorMessage = "Please Enter Year")]
        [DisplayName("Year")]
        public string YearOfRelease { get; set; }
        [Required(ErrorMessage = "Please Enter Plot of Movie")]
        public string Plot { get; set; }
        [DisplayName("Producer")]
        public int producerid { get; set; }
        
    }
    [MetadataType(typeof(newupdated))]
    public partial class updatedActors
    {
    }

    public class newupdated
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [DisplayName("Actor")]
        public string Actor1 { get; set; }
        [DisplayName("SEX")]
        [Required(ErrorMessage = "Please Select Gender")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Please Enter DOB")]
        [DisplayName("Date of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required(ErrorMessage = "Please Enter Bio")]
        public string Bio { get; set; }

    }


    [MetadataType(typeof(updateProducers))]
    public partial class Producers
    {

    }
    public class updateProducers
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [DisplayName("Name")]
        public string ProducersName { get; set; }

        [DisplayName("Sex")]
        [Required(ErrorMessage = "Please Select Gender")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Please Enter DOB")]
        [DisplayName("Date of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Bio")]
        public string Bio { get; set; }
    }

    [MetadataType(typeof(viewallmoviesPartial))]
    public partial class viewAllMovies_Result
    {

    }

    public class viewallmoviesPartial
    {
      


        [DisplayName("Movie Name")]
        public string MoviesName { get; set; }


        public string plot { get; set; }

        [DisplayName("Producer Name")]
        public string ProducersName { get; set; }

        [DisplayName("Actors")]
        public string Actor1 { get; set; }
    }
}