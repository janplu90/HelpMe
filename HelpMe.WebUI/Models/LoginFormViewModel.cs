using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpMe.WebUI.Models
{
    public class LoginFormViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool ErrorMessage { get; set; }
    }
}