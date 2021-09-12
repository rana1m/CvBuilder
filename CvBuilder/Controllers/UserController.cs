using CvBuilder.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CvBuilder.Controllers
{

   
    public class UserController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
       
        public ActionResult PersonalInfo()
        {
           
            var userId = User.Identity.GetUserId();
            var UserAdded = db.UserInfo.Where(a => a.applicationUser.Id.Equals(userId)).FirstOrDefault();
            if (UserAdded != null)
            {
                return View(UserAdded);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult PersonalInfo(UserInfo userInfo)
        {
            UserInfo UserInfo_ = new UserInfo();

            UserInfo_.FirstName = userInfo.FirstName;
            UserInfo_.applicationUser = db.Users.Find(User.Identity.GetUserId());
            UserInfo_.LastName = userInfo.LastName;
            UserInfo_.BirthDate = userInfo.BirthDate;
            UserInfo_.PhoneNumber = userInfo.PhoneNumber;
            UserInfo_.Summary = userInfo.Summary;
           
            if (UserInfo_.applicationUser != null)
            {
                db.UserInfo.Add(UserInfo_);
            }
         

            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


            return View(UserInfo_);
        }

        [HttpPost]
        public ActionResult EditPersonalInfo(UserInfo userInfo)
        {
            var userId = User.Identity.GetUserId();
            var UserAdded = db.UserInfo.Where(a => a.applicationUser.Id.Equals(userId)).FirstOrDefault();
            UserAdded.FirstName = userInfo.FirstName;
            UserAdded.LastName = userInfo.LastName;
            UserAdded.BirthDate = userInfo.BirthDate.Date;
            UserAdded.PhoneNumber = userInfo.PhoneNumber;
            UserAdded.Summary = userInfo.Summary;


            //db.Educations.Add(w);
            UserAdded.Educations = new List<Education>();
            Education w = new Education()
            {
                Name = "w",
                userInfo = UserAdded,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now


            };
            db.Educations.Add(w);
            UserAdded.Educations.Add(w);
            
            Console.WriteLine(UserAdded.Educations);
            if (UserAdded.applicationUser != null)
            {
                db.SaveChanges();
            }
           
            return RedirectToAction("PersonalInfo", "User");
        }

        public ActionResult ShowEducations()
        {
            var userId = User.Identity.GetUserId();
            var UserAdded = db.UserInfo.Where(a => a.applicationUser.Id.Equals(userId)).Include(a=>a.Educations).FirstOrDefault();

            if (UserAdded != null)
            {
                if (UserAdded.Educations != null)
                {
                    return View(UserAdded.Educations.ToList());
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddEducation()
        {
    
                return View();
            
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddEducation(Education education)
        {
            var userId = User.Identity.GetUserId();
            var UserAdded = db.UserInfo.Where(a => a.applicationUser.Id.Equals(userId)).FirstOrDefault();
  
            
            UserAdded.Educations = new List<Education>();
            Education w = new Education()
            {
                Name = education.Name,
                userInfo = UserAdded,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Specialty=education.Specialty
                
            };
            db.Educations.Add(w);
            UserAdded.Educations.Add(w);

            Console.WriteLine(UserAdded.Educations);
            if (UserAdded.applicationUser != null)
            {
                db.SaveChanges();
            }
            return RedirectToAction("ShowEducations", "User");
        }

        public ActionResult EditEducation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEducation([Bind(Include = "Id,Name,StartDate,EndDate,Specialty")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowEducations");
            }
            return View(education);
        }

        public ActionResult DeleteEducation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("DeleteEducation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedEducation(int id)
        {
            Education education = db.Educations.Find(id);
            db.Educations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("ShowEducations");
        }

        public ActionResult ShowExperiences()
        {
            var userId = User.Identity.GetUserId();
            var UserAdded = db.UserInfo.Where(a => a.applicationUser.Id.Equals(userId)).Include(a => a.Experiences).FirstOrDefault();

            if (UserAdded != null)
            {
                if (UserAdded.Experiences != null)
                {
                    return View(UserAdded.Experiences.ToList());
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddExperiences()
        {

            return View();

        }

        [HttpPost]
        [Authorize]
        public ActionResult AddExperiences(Experiences experiences)
        {
            var userId = User.Identity.GetUserId();
            var UserAdded = db.UserInfo.Where(a => a.applicationUser.Id.Equals(userId)).FirstOrDefault();


            UserAdded.Experiences = new List<Experiences>();
            Experiences w = new Experiences()
            {
                Company = experiences.Company,
                Position = experiences.Position,
                City = experiences.City,
                userInfo = UserAdded,
                StartDate = experiences.StartDate,
                EndDate = experiences.EndDate,

            };
            db.Experiences.Add(w);
            UserAdded.Experiences.Add(w);

            Console.WriteLine(UserAdded.Educations);
            if (UserAdded.applicationUser != null)
            {
                db.SaveChanges();
            }
            return RedirectToAction("ShowExperiences", "User");
        }

        public ActionResult EditExperiences(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences experiences = db.Experiences.Find(id);
            if (experiences == null)
            {
                return HttpNotFound();
            }
            return View(experiences);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExperiences([Bind(Include = "Id,Company,Position,City,StartDate,EndDate")] Experiences experiences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowExperiences");
            }
            return View(experiences);
        }

        public ActionResult DeleteExperiences(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences experiences = db.Experiences.Find(id);
            if (experiences == null)
            {
                return HttpNotFound();
            }
            return View(experiences);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("DeleteExperiences")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedExperiences(int id)
        {
            Experiences experiences = db.Experiences.Find(id);
            db.Experiences.Remove(experiences);
            db.SaveChanges();
            return RedirectToAction("ShowExperiences");
        }

        public ActionResult ShowCv()
        {
            var userId = User.Identity.GetUserId();
            var UserAdded = db.UserInfo.Where(a => a.applicationUser.Id.Equals(userId)).Include(a=>a.Educations).Include(a => a.Experiences).FirstOrDefault();

            if (UserAdded != null)
            {
              
               return View(UserAdded);
            
            }
            else
            {
                return View();
            }
        }
    }


}