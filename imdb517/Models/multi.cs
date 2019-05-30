using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace imdb517.Models
{
    public class multi
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Requirde")]
        [DisplayName("Movie Name")]
        public string MoviesName { get; set; }
        [Required(ErrorMessage = "Please Select Year")]
        [DisplayName("Year")]
        public Nullable<System.DateTime> YearOfRelease { get; set; }

        [Required(ErrorMessage = "Please Enter Plot")]
        [DisplayName("Plot")]
        public string Plot { get; set; }

        [Required(ErrorMessage = "Please Enter Image Url")]
        [DisplayName("Image Url")]
        public string image { get; set; }

        [DisplayName("Producer")]
        public Nullable<int> producerid { get; set; }

        [DisplayName("Actor")]
        public Nullable<int> Actorid { get; set; }

        public int ProId { get; set; }

        
        [DisplayName("Producer")]
        public string ProducersName { get; set; }

        
        [DisplayName("Sex")]
        public string Sex { get; set; }

      
        [DisplayName("Date of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }

        
        [DisplayName("Bio")]
        public string Bio { get; set; }


        
        [DisplayName("Actor")]
        public string Actor1 { get; set; }

        
        [Required(ErrorMessage = "Please Select Gender")]
        public string Actor1Sex { get; set; }

        
        [DisplayName("Date of Birth")]
        public Nullable<System.DateTime> Actor1DOB { get; set; }

        
        [DisplayName("Bio")]
        public string Actor1Bio { get; set; }

    }
}