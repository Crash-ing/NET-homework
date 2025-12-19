using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public enum SpecializationType      // pārskaitāmā tips
    {
        Hardware,
        Software,
        Network,
        Security
    }

    public class ITSupport : User
    {
        public SpecializationType Specialization { get; set; }

        public ITSupport() { }  // tukšais konstruktors

        public ITSupport(string user_name, string email, int id, bool is_active, SpecializationType specialization)     // konstruktors ar parametriem
        {
            UserID = id;
            Email = email;
            UserName = user_name;
            IsActive = is_active;
            Specialization = specialization;
        }

        public override string? ToString()  // Pārdefinēta metode ToString(), lai atgrieztu visu īpašību vērtības kā tekstu
        {
            return base.ToString() + " Specialization: " + Specialization;
        }
    }
}
