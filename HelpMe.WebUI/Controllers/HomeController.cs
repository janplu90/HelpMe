using HelpMe.Domain.Abstract;
using HelpMe.Domain.Entities;
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
        private IReviewRepository reviewRepository;


        public HomeController(IUserRepository userRepository, IReviewRepository reviewRepository)
        {
            this.repository = userRepository;
            this.reviewRepository = reviewRepository;
            //repository.AddUser();
            //repository.DeleteUser();
            // repository.UpdateUser();
            TestujemySobie(userRepository, reviewRepository);
        }

        public ViewResult UserInfo(int page = 1)
        {
            return View(repository.Users);
        }

        public void TestujemySobie(IUserRepository repo, IReviewRepository reviewRepo)
        {
            User userBy = new User();
            User userFor = new User();
            var userList = repo.Users.ToList();
            foreach(User user in userList)
            {
                if (user.Name == "Lebron")
                {
                    userBy = user;
                }
                else if(user.Name == "Casey")
                {
                    userFor = user;
                }
            }

            reviewRepo.AddReview(new Review { Description = "Pierwsze review", Recommendation = true, WrittenByID = userBy.UserID, WrittenForID = userFor.UserID });

            
        }
    }
}