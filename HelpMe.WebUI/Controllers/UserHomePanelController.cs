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
    public class UserHomePanelController : Controller
    {
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        public int PageSize = 2;


        public UserHomePanelController(IUserRepository userRepository, IEventRepository eventRepository)
        {
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
        }

        public ViewResult UserHomePanelForm(string category, int page = 1, string city = null)
        {
            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);

            List<Event> events = new List<Event>();
            foreach (Event e in eventRepository.Events)
            {
                if(e.CreatorID != user.UserID && e.HelperID != user.UserID && (DateTime.Compare(e.Date, DateTime.Now) > 0) && !e.IsAcctepted.HasValue)
                {
                    events.Add(e);
                }
            }

            EventListViewModel model;

            if (city == null)
            {
                model = new EventListViewModel
                {
                    Events = events
                    .Where(p => category == null || p.Category == category)
                     .OrderBy(p => p.EventID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                            events.Count() :
                            eventRepository.Events.Where(e => e.Category == category).Count()
                    },
                    CurrentCategory = category
                };
            }
            else
            {
                model = new EventListViewModel
                {
                    Events = events
                   .Where(p => (category == null || p.Category == category) && p.Place == city)
                    .OrderBy(p => p.EventID)
                       .Skip((page - 1) * PageSize)
                       .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                          events.Where(e => e.Place == city).Count() :
                           events.Where(e => e.Category == category && e.Place == city).Count()
                    },
                    CurrentCategory = category,
                    CurrentCity = city
                };
            }
            return View(model);
        }

        public ViewResult AddEventForm()
        {
            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);
            ViewBag.UserID = user.UserID;
            return View();
        }

        //public ViewResult AddEventForm()
        //{
        //    var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
        //    var user = userRepository.getUser(userLogin);
        //    ViewBag.UserID = user.UserID;


        //    return View(new AddEventViewModel() { Categories = new List<Category>() { Category.Accommodation, Category.Culture, Category.Food, Category.Sightseeing, Category.Transport, Category.Other}  });
        //}

        [HttpPost]
        public ActionResult AddEventForm(Event e)
        {
            if (ModelState.IsValid)
            {
                var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
                var user = userRepository.getUser(userLogin);
                e.CreatorID = user.UserID;
                e.ImageData = user.ImageData;
                e.ImageMimeType = user.ImageMimeType;
                eventRepository.AddEvent(e);
                return RedirectToActionPermanent("UserHomePanelForm", "UserHomePanel");
            }
            else
                return View();
        }

        //[HttpPost]
        //public ActionResult AddEventForm(AddEventViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
        //        var user = userRepository.getUser(userLogin);
        //        model.Event.CreatorID = user.UserID;
        //        model.Event.ImageData = user.ImageData;
        //        model.Event.ImageMimeType = user.ImageMimeType;
        //        eventRepository.AddEvent(model.Event);
        //        return RedirectToActionPermanent("UserHomePanelForm", "UserHomePanel");
        //    }
        //    else
        //        return View();
        //}

        public ViewResult YourEventsForm(int page = 1)
        {
            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);

            List<Event> events = new List<Event>();
            foreach (Event e in eventRepository.Events)
            {
                if (e.CreatorID == user.UserID && e.ReviewedByCreator.HasValue == false)
                {
                    events.Add(e);
                }
            }

            EventListViewModel model = new EventListViewModel
            {
                Events = events
                 .OrderBy(u => u.EventID)
                    .Skip((page - 1) * PageSize) 
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = events.Count()
                }
            };
            return View(model);
        }

        public ViewResult AcceptedEventsForm(int page = 1)
        {
            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);

            List<Event> events = new List<Event>();
            foreach (Event e in eventRepository.Events)
            {
                if (e.HelperID == user.UserID && e.ReviewedByHelper.HasValue == false)
                {
                    events.Add(e);
                }
            }

            EventListViewModel model = new EventListViewModel
            {
                Events = events
                 .OrderBy(u => u.EventID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = events.Count()
                }
            };
            return View(model);
        }
     

        public FileContentResult GetImageForEvent(int eventID)
        {
            Event e = eventRepository.getEvent(eventID);
            if (e != null)
            {
                return File(e.ImageData, e.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetImageForProfile(int userID)
        {
            User u = userRepository.getUser(userID);
            if (u != null)
            {
                return File(u.ImageData, u.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult SearchCity(string searchCityText)
        {
            string test = searchCityText;
            return RedirectToAction("UserHomePanelForm", "UserHomePanel", new { city = searchCityText } );
        }


    }
}