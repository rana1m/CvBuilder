using CvBuilder.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBuilder.Controllers
{

   
    public class UserController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Forms()
        {
            UserInfo UserInfo_ = new UserInfo();
           ApplicationUser user= db.Users.Find(User.Identity.GetUserId());
            UserInfo_.UserId = user.Id;

            return View(UserInfo_);
        }

        [HttpPost]
        public ActionResult Forms(UserInfo userInfo)
        {
            UserInfo UserInfo_ = new UserInfo();
          
            UserInfo_.FirstName = userInfo.FirstName;
            UserInfo_.LastName = userInfo.LastName;
            UserInfo_.UserId = userInfo.UserId;
            UserInfo_.Age = userInfo.Age;
           
            db.UserInfo.Add(UserInfo_);
            db.SaveChanges();
    

            return View(UserInfo_);
        }

    }
}