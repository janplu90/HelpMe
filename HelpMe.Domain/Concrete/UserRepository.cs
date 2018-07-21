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

        public void AddUser()
        {
            //User testowy = new User();
            //testowy = context.Users.First();
            context.Users.Add(new User { Name = "Lebron", Surname = "James", Login = "LBJ", Password = "0000", Country = "USA", City = "Cleveland", Age = 33 });
            context.SaveChanges();
            //context.Users.Add(testowy);
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
            var test = context.Users.SingleOrDefault(t => t.Name == "Lebron");

            if (test != null)
            {
                test.Login = "LBJ23";
                context.SaveChanges();
            }
         
        }




    }
}
