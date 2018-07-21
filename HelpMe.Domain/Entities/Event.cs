using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Entities
{
    public class Event
    {
        public int EventID { get; set; }
        public User UserID { get; set; }
        public User HelperID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public bool IsAcctepted { get; set; }
        public bool IsDone { get; set; }
    }
}
