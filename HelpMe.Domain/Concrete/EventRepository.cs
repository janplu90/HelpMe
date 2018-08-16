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

        public void deleteEvent(int eventID)
        {
            Event eventToBeDeleted = context.Events.FirstOrDefault(e => e.EventID == eventID);
            context.Events.Remove(eventToBeDeleted);
            context.SaveChanges();
        }

        public void updateEventHelperReview(int eventID)
        {
            Event toUpdate = context.Events.SingleOrDefault(e => e.EventID == eventID);
            toUpdate.ReviewedByHelper = true;
            context.SaveChanges();
        }

        public void updateEventCreatorReview(int eventID)
        {
            Event toUpdate = context.Events.SingleOrDefault(e => e.EventID == eventID);
            toUpdate.ReviewedByCreator = true;
            context.SaveChanges();
        }

    }
}
