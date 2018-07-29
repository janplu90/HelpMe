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
            if(repository.CheckIfUserExists(model.Login))
            {
                if (repository.CheckPassword(model.Login, model.Password))
                {
                    return View("~/Views/Home/GoTo.cshtml");
                }
                else
                {
                    model.ErrorMessage = true;
                    return View(model);
                }
            }
            else
            {
                model.ErrorMessage = true;
                return View(model);
            }
        }

        public ViewResult RegisterForm()
        {
            return View("Register");
        }
    }
}