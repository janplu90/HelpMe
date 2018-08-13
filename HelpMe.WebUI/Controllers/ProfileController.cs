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
    }
}