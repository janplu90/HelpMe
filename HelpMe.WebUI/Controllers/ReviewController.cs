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
        private int reviewerID;
        private int revieweeID;

        public ReviewController(IUserRepository userRepository, IReviewRepository reviewRepository)
        {
            this.userRepository = userRepository;
            this.reviewRepository = reviewRepository;
        }

        public ActionResult WriteReviewForm(int reviewerID, int revieweeID)
        {
            this.reviewerID = reviewerID;
            this.revieweeID = revieweeID;

            return View(new ReviewFormViewModel());
        }

        [HttpPost]
        public ActionResult WriteReviewForm(ReviewFormViewModel model)
        {
           User u = userRepository.getUser(reviewerID);
            reviewRepository.AddReview(new Domain.Entities.Review { WrittenByID = reviewerID, WrittenForID = revieweeID, WrittenByName = u.Name, Description = model.Description, Recommendation = model.Recommendation });
            return RedirectToActionPermanent("AcceptedEventsForm", "UserHomePanel");
        }
    }
}