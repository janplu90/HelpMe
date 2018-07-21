using HelpMe.Domain.Abstract;
using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Concrete
{
    public class ReviewRepository : IReviewRepository
    {
        private HelpMeDBContext context = new HelpMeDBContext();

        public IEnumerable<Review> Reviews
        {
            get { return context.Reviews; }
        }

        public void AddReview(Review review)
        {

            context.Reviews.Add(review);
            context.SaveChanges();

        }
    }
}
