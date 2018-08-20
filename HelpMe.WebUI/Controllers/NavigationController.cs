using HelpMe.Domain.Abstract;
using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpMe.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IEventRepository eventRepository;
        private IUserRepository userRepository;
        public NavigationController(IEventRepository eventRepository, IUserRepository userRepository)
        {
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
        }
       public PartialViewResult LeftBar(string category = null)
        {
            ViewBag.SelectedCategory = category;
            List<string> categories = new List<string> { "Sightseeing", "Transport", "Food", "Lodge", "Other" };
            return PartialView(categories);
        }

    }
}