using Domain.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class DBContext:DbContext
    {


        public DBContext():base("AcademiaDB")
        {
                
        }


        public DbSet<Article> Article { get; set; }

        public DbSet<User> User { get; set; }
    }
}
