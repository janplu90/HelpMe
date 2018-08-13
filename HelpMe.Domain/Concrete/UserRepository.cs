using HelpMe.Domain.Abstract;
using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Concrete
{
    public class UserRepository : IUserRepository
    {
        private HelpMeDBContext context = new HelpMeDBContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        ////RECZNIE
        //public void AddUser()
        //{
        //    context.Users.Add(new User { Name = "Lebron", Surname = "James", Login = "LBJ", Password = "0000", Country = "USA", City = "Cleveland", Age = 33 });
        //    context.SaveChanges();
        //}

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser()
        {
            User testowy = new User();
            List<User> listaTestowa = new List<User>();
            listaTestowa = context.Users.ToList();
            foreach( User user in listaTestowa)
            {
                if (user.Login == "LBJ")
                {
                    testowy = user;
                    context.Users.Remove(testowy);
                    context.SaveChanges();
                }
                }
           
        }

        public void UpdateUser()
        {
            var test = context.Users.SingleOrDefault(t => t.Name == "Casey");

         
         
        }

        public bool CheckIfUserExists(string login)
        {
            var user = context.Users.SingleOrDefault(u => u.Login == login);
            if (user == null)
                return false;
            else
                return true;

        }

        public bool CheckPassword(string login, string password)
        {
            var user = context.Users.SingleOrDefault(u => u.Login == login);
            if (user.Password == password)
                return true;
            else
                return false;
        }

        public User getUser(string login)
        {
            var user = context.Users.SingleOrDefault(u => u.Login == login);
            return user;

        }

        public User getUser(int userID)
        {
            var user = context.Users.SingleOrDefault(u => u.UserID == userID);
            return user;

        }



    }
}
