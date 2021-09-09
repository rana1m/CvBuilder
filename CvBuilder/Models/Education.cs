using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBuilder.Models
{
    public class Education
    {
        public int Id { get; set; }
        public UserInfo userInfo { get; set; }
        public String Name { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String Specialty { get; set; }
       

    }
}