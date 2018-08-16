using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Abstract
{
    public interface IEventRepository
    {
        IEnumerable<Event> Events { get; }
        void AddEvent(Event e);
        Event getEvent(int eventID);
        void acceptEvent(int eventID, int userID);
        void deleteEvent(int eventID);
        void updateEventHelperReview(int eventID);
        void updateEventCreatorReview(int eventID);
    }
}
