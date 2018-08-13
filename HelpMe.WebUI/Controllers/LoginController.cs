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
        public ActionResult LoginForm(LoginFormViewModel model)
        {
            if(repository.CheckIfUserExists(model.Login))
            {
                if (repository.CheckPassword(model.Login, model.Password))
                {
                    System.Web.HttpContext.Current.Session["UserLogin"] = model.Login;
                    return RedirectToActionPermanent("UserHomePanelForm", "UserHomePanel");
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
            return View();
        }

        [HttpPost]
        public ActionResult RegisterForm(User user, HttpPostedFileBase image = null)
        {
            if(ModelState.IsValid)
            {
                if (image != null)
                {
                    user.ImageMimeType = image.ContentType;
                    user.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(user.ImageData, 0, image.ContentLength);
                }
                repository.AddUser(user);
                return RedirectToAction("LoginForm", "Login");
            }
            else
            return View();
        }
    }
}