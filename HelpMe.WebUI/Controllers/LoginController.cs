using HelpMe.Domain.Abstract;
using HelpMe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpMe.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository repository;


        public LoginController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public ViewResult LoginForm()
        {
            return View(new LoginFormViewModel());
        }

        [HttpPost]
        public ViewResult LoginForm(LoginFormViewModel model)
        {
            if (model.Login == "jan")
                return View("~/Views/Home/GoTo.cshtml");
            else
                return View("Error");
        }

        public ViewResult RegisterForm()
        {
            return View("Register");
        }
    }
}