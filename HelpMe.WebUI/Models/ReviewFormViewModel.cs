using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpMe.WebUI.Models
{
    public class ReviewFormViewModel
    {
        public string Description { get; set; }
        public string Recommendation { get; set; }
        public int ReviewerID { get; set; }
        public int RevieweeID { get; set; }
        public string ReviewerName { get; set; }
    }
}