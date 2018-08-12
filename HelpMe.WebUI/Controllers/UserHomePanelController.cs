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

        public ViewResult UserHomePanelForm(string category, int page = 1)
        {

            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);

            List<Event> events = new List<Event>();
            foreach (Event e in eventRepository.Events)
            {
                if(e.CreatorID != user.UserID && e.HelperID != user.UserID)
                {
                    events.Add(e);
                }
            }
                
            EventListViewModel model = new EventListViewModel {
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
            return View(model);
        }

        public ViewResult AddEventForm()
        {
            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);
            ViewBag.UserID = user.UserID;
            return View();
        }

        [HttpPost]
        public ActionResult AddEventForm(Event e)
        {
            if (ModelState.IsValid)
            {
                var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
                var user = userRepository.getUser(userLogin);
                e.CreatorID = user.UserID;
                eventRepository.AddEvent(e);
                return RedirectToActionPermanent("UserHomePanelForm", "UserHomePanel");
            }
            else
                return View();
        }

        public ViewResult YourEventsForm(int page = 1)
        {
            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);


         
            EventListViewModel model = new EventListViewModel
            {
                Events = eventRepository.Events
                .Where(u => u.CreatorID == user.UserID)
                 .OrderBy(u => u.EventID)
                    .Skip((page - 1) * PageSize) 
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = eventRepository.Events.Where(e => e.CreatorID == user.UserID).Count()
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
                if (e.HelperID == user.UserID)
                {
                    events.Add(e);
                }
            }

            EventListViewModel model = new EventListViewModel
            {
                Events = eventRepository.Events
                .Where(u => u.HelperID == user.UserID)
                 .OrderBy(u => u.EventID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = eventRepository.Events.Where(e => e.HelperID == user.UserID).Count()
                }
            };
            return View(model);
        }



    }
}