using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace yousef_walled
{
   public class dbconnection:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet <Task> Tasks { get; set; }

    }
}
