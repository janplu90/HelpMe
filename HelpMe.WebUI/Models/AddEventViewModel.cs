using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpMe.WebUI.Models
{
    public class AddEventViewModel
    {
        public Event Event { get; set; }
        //public IEnumerable<string> Categories { get; set; }
        //public IEnumerable<SelectListItem> CategoryItems
        //{
        //    get { return new SelectList(Categories, "Id", "Name"); }
        //}

        public int SelectedCategoryId { get; set; }
        public List<Category> Categories { get; set; }
        public Category category { get; set; }
    }
}