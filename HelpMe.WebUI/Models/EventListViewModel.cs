using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpMe.WebUI.Models
{
    public class EventListViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentCity { get; set; }
    }
}