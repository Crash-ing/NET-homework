using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class Employee : User
    {
        public DateTime ContractDate { get; set; }

        public override string? ToString()  // Pārdefinēta metode ToString(), lai atgrieztu visu īpašību vērtības kā tekstu
        {
            return base.ToString() + " Contract Date: " + ContractDate + ";";
        }
    }
}
