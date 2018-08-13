using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpMe.WebUI.Models
{
    public class ProfileDescriptionViewModel
    {
        public User User { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public string reviewerName { get; set; }
    }
}