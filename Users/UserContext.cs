using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Users;

namespace User
{
    public class UserContext : DbContext
    {
        public UserContext() { }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                string cs = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ITSupport> ITSupports { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Assignement> Assignements { get; set; }

    }
}
