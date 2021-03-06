﻿using HelpMe.Domain.Entities;
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
        public int EventID { get; set; }
        public User Reviewee { get; set; }
        public bool IsCreator { get; set; }
    }
}