using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace User
{
    public class DataStore      // klase, kas satur kolekcijas visiem datu veidiem
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<ITSupport> ITSupports { get; set; } = new List<ITSupport>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<Assignement> Assignements { get; set; } = new List<Assignement>();
    }
}
