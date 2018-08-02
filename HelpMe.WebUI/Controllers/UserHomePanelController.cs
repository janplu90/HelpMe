using HelpMe.Domain.Abstract;
using HelpMe.Domain.Entities;
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


        public UserHomePanelController(IUserRepository userRepository, IEventRepository eventRepository)
        {
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
        }

        public ViewResult UserHomePanelForm()
        {
            //string test = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            return View(eventRepository.Events);
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
                return View("UserHomePanelForm");
            }
            else
                return View();
        }



    }
}