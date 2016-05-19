using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Empl
{
    class Empleycontext : DbContext
    {
        public Empleycontext() : base("DBConnection") {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}

