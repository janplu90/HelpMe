using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public List<Event> events;
        public List<Review> reviews;
    }
}
