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
    }
}
