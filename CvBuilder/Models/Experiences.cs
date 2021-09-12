using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvBuilder.Models
{
    public class Experiences
    {
        public int Id { get; set; }
        public UserInfo userInfo { get; set; }
        [Display(Name = "Company")]
        public String Company { get; set; }
        public String Position { get; set; }
        public String City { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]

        public DateTime EndDate { get; set; }




    }
}