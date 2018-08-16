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
        private IEventRepository eventRepository;
     
        public ReviewController(IUserRepository userRepository, IReviewRepository reviewRepository, IEventRepository eventRepository)
        {
            this.userRepository = userRepository;
            this.reviewRepository = reviewRepository;
            this.eventRepository = eventRepository;
        }

        public ActionResult WriteReviewHelper(int reviewerID, int revieweeID, int eventID)
        {
            eventRepository.updateEventHelperReview(eventID);
            Event e = eventRepository.getEvent(eventID);
            return RedirectToAction("WriteReviewForm", "Review", new { reviewerID = reviewerID, revieweeID = revieweeID, eventID = eventID } );
        }

        public ActionResult WriteReviewCreator(int reviewerID, int revieweeID, int eventID)
        {
            eventRepository.updateEventCreatorReview(eventID);
            Event e = eventRepository.getEvent(eventID);
            return RedirectToAction("WriteReviewForm", "Review", new { reviewerID = reviewerID, revieweeID = revieweeID, eventID = eventID });
        }

        public ActionResult WriteReviewForm(int reviewerID, int revieweeID, int eventID)
        {
            User u = userRepository.getUser(reviewerID);
            ViewBag.ReviewerID = reviewerID;
            ViewBag.RevieweeID = revieweeID;
            ViewBag.ReviewerName = u.Name;
            ViewBag.EventID = eventID;

            Event eventToPass = eventRepository.getEvent(eventID);
            bool test = eventToPass.ReviewedByHelper ?? false;
            bool test2 = eventToPass.ReviewedByCreator ?? false;

            return View(new ReviewFormViewModel());
        }

        [HttpPost]
        public ActionResult WriteReviewForm(ReviewFormViewModel model)
        {
            string test = model.Recommendation;
            string test2 = model.Description;
            Event e = eventRepository.getEvent(model.EventID);
            if ( (e.ReviewedByHelper.HasValue && e.ReviewedByHelper == true) && (e.ReviewedByCreator.HasValue && e.ReviewedByCreator == true))
            {
                eventRepository.deleteEvent(e.EventID);
            }

            reviewRepository.AddReview(new Domain.Entities.Review { WrittenByID = model.ReviewerID, WrittenForID = model.RevieweeID , WrittenByName = model.ReviewerName, Description = model.Description, Recommendation = model.Recommendation });
            if (e.HelperID == model.ReviewerID)
            {
                return RedirectToActionPermanent("AcceptedEventsForm", "UserHomePanel");
            }
            else
            {
                return RedirectToActionPermanent("YourEventsForm", "UserHomePanel");
            }
        }
    }
}