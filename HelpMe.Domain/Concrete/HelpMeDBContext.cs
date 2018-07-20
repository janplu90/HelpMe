using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Concrete
{
    class HelpMeDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
