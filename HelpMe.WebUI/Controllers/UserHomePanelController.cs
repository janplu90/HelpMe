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
            EventListViewModel model = new EventListViewModel {
                Events = eventRepository.Events
                .Where(p => category == null || p.Category == category)
                 .OrderBy(p => p.EventID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        eventRepository.Events.Count() :
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



    }
}