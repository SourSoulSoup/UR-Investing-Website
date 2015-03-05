using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UR_Investing.Models
{
    public class ContactModel
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Picture")]
        [FileExtensions(ErrorMessage = "Please enter a valid file name with the extension \".png, .jpg, .jpeg, or .gif\"", Extensions = ".png,.jpg,.jpeg,.gif")]
        public string picturePath { get; set; }

    }
}