using HelpMe.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpMe.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repository;


        public HomeController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public ViewResult UserInfo(int page = 1)
        {
            return View(repository.Users);
        }
    }
}