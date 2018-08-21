using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpMe.Domain.Entities
{
    public class User
    {
        [HiddenInput(DisplayValue=false)]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please fill up your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill up your surname")]
        public string Surname { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Please fill up your login")]
        public string Login { get; set; }
        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill up your password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please fill up your country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please fill up your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please fill up your age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please fill up your description")]
        public string AboutMe { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
