using HelpMe.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpMe.WebUI.Controllers
{
    public class EventController : Controller
    {
        private IUserRepository userRepository;
        private IEventRepository eventRepository;


        public EventController(IUserRepository userRepository, IEventRepository eventRepository)
        {
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
        }

        public ActionResult AcceptEvent(int eventID)
        {
            var accteptedEvent = eventRepository.getEvent(eventID);

            var userLogin = System.Web.HttpContext.Current.Session["UserLogin"].ToString();
            var user = userRepository.getUser(userLogin);

            eventRepository.acceptEvent(eventID, user.UserID);

            return RedirectToAction("UserHomePanelForm", "UserHomePanel");

            
        }

        public ActionResult DeleteCreatedEvent(int eventID)
        {
            eventRepository.deleteEvent(eventID);

            return RedirectToAction("YourEventsForm", "UserHomePanel");


        }
   
        
    }
}