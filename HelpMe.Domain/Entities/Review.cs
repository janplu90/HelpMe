using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Entities
{
    public class Review
    {
        public User WrittenBy { get; set; }
        public User WrittenFor { get; set; }
        public string Descritpion { get; set; }
        public int Grade { get; set; }
    }
}
