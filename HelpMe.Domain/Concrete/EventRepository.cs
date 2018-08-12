using HelpMe.Domain.Abstract;
using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Concrete
{
    public class EventRepository : IEventRepository
    {
        private HelpMeDBContext context = new HelpMeDBContext();

        public IEnumerable<Event> Events
        {
            get { return context.Events; }
        }

        public void AddEvent(Event e)
        {

            context.Events.Add(e);
            context.SaveChanges();
        }

        public Event getEvent(int eventID)
        {
            var e = context.Events.SingleOrDefault( u => u.EventID == eventID);
            return e;
        }

        public void acceptEvent(int eventID, int userID)
        {
            var e = context.Events.SingleOrDefault(u => u.EventID == eventID);
            e.IsAcctepted = true;
            e.HelperID = userID;
            context.SaveChanges();
        }
    }
}
