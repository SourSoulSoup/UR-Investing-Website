using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UR_Investing.Models
{
    public class HomePage
    {
        public string mainTitle { get; set;}
        public string mainBody;
        public string columnTitle1;
        public string columnBody1;
        public string columnLink1;
        public string columnTitle2;
        public string columnLink2;
        public string columnTitle3;
        public string columnBody3;
        public string columnLink3;
    }

    public class CarouselItems
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string title { get; set; }
        public string caption { get; set;} 
        public string filepath { get; set; }
        public int rank { get; set; }
    }

    public class Contact
    {
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string email { get; set; }
    }
}