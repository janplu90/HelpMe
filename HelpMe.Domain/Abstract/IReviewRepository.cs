﻿using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Abstract
{
    public interface IReviewRepository
    {
        IEnumerable<Review> Reviews { get; }
        void AddReview(Review review);
    }
}
