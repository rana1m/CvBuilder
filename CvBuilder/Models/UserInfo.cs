using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBuilder.Models
{
    public class UserInfo
    {
       
        public int id { get; set; }
 
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public  ApplicationUser applicationUser { get; set; }
        public ICollection<Education> Educations { get; set; }


    }
}