using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please fill up your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill up your surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please fill up your login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Please fill up your password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please fill up your country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please fill up your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please fill up your age")]
        public int Age { get; set; }
        public List<Event> events;
        public List<Review> reviews;
    }
}
