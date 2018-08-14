using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int WrittenByID { get; set; }
        public int WrittenForID { get; set; }
        public string WrittenByName { get; set; }
        public string Description { get; set; }
        public string Recommendation { get; set; }
    }
}
