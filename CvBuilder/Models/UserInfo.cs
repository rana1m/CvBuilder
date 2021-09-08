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

        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser applicationUser { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }

    }
}