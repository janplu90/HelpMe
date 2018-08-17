using HelpMe.Domain.Abstract;
using HelpMe.Domain.Entities;
using HelpMe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpMe.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private IUserRepository userRepository;
        private IReviewRepository reviewRepository;

        public ProfileController(IUserRepository userRepository, IReviewRepository reviewRepository)
        {
            this.userRepository = userRepository;
            this.reviewRepository = reviewRepository;
        }

        public ActionResult ProfileDescription(int userID)
        {
            User user = userRepository.Users.SingleOrDefault(u => u.UserID == userID);
            List<Review> reviews = new List<Review>();
           foreach(Review rev in reviewRepository.Reviews)
            {
                if(rev.WrittenForID == user.UserID)
                {
                    reviews.Add(rev);
                }
            }
           
            ProfileDescriptionViewModel model = new ProfileDescriptionViewModel { User = user, Reviews = reviews};
            return View(model);
        }

        public ActionResult UserProfile()
        {
            User user = userRepository.getUser(System.Web.HttpContext.Current.Session["UserLogin"].ToString());
            List<Review> reviews = new List<Review>();
            foreach (Review rev in reviewRepository.Reviews)
            {
                if (rev.WrittenForID == user.UserID)
                {
                    reviews.Add(rev);
                }
            }

            ProfileDescriptionViewModel model = new ProfileDescriptionViewModel { User = user, Reviews = reviews };
            return View(model);
        }

        public ActionResult EditProfile(int userID)
        {
            User user = userRepository.Users.SingleOrDefault(u => u.UserID == userID);
           
            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserID = userRepository.getUser(System.Web.HttpContext.Current.Session["UserLogin"].ToString()).UserID;
                userRepository.UpdateUser(user);
                TempData["message"] = string.Format("Your changes have been saved");
                return RedirectToAction("UserProfile");
            }

            return View(user);
        }


    }
}