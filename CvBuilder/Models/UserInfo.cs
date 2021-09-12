using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CvBuilder.Models
{
    public class UserInfo
    {
       
        public int id { get; set; }

        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Display(Name = "Birth Date")]
         [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public String PhoneNumber { get; set; }
        public String Summary { get; set; }

        public virtual  ApplicationUser applicationUser { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experiences> Experiences { get; set; }


    }
}