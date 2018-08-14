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
    public class ReviewController : Controller
    {
        private IUserRepository userRepository;
        private IReviewRepository reviewRepository;
     
        public ReviewController(IUserRepository userRepository, IReviewRepository reviewRepository)
        {
            this.userRepository = userRepository;
            this.reviewRepository = reviewRepository;
        }

        public ActionResult WriteReviewForm(int reviewerID, int revieweeID)
        {
            User u = userRepository.getUser(reviewerID);
            ViewBag.ReviewerID = reviewerID;
            ViewBag.RevieweeID = revieweeID;
            ViewBag.ReviewerName = u.Name;

            return View(new ReviewFormViewModel());
        }

        [HttpPost]
        public ActionResult WriteReviewForm(ReviewFormViewModel model)
        {
            string test = model.Recommendation;
            string test2 = model.Description;
            reviewRepository.AddReview(new Domain.Entities.Review { WrittenByID = model.ReviewerID, WrittenForID = model.RevieweeID , WrittenByName = model.ReviewerName, Description = model.Description, Recommendation = model.Recommendation });
            return RedirectToActionPermanent("AcceptedEventsForm", "UserHomePanel");
        }
    }
}