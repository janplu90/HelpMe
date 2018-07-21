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
        public int CreatorID { get; set; }
        public Nullable<int> HelperID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public Nullable<bool> IsAcctepted { get; set; }
        public Nullable<bool> IsDone { get; set; }
    }
}
