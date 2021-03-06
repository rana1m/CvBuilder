using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBuilder.Models
{
    public class Education
    {
        public int Id { get; set; }
        public UserInfo userInfo { get; set; }
        [Display(Name = "School/College")]
        public String Name { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]

        public DateTime EndDate { get; set; }
        [Display(Name = "Degree")]
        public String Specialty { get; set; }
       

    }
}