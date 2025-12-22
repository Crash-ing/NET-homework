using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace User
{
    public class Assignement
    {
        public int ID { get; set; }
        public DateTime AssignedAt { get; set; }
        public ITSupport Support { get; set; }    
        public Ticket Ticket { get; set; }       
        public string Comment { get; set; }      
        public override string? ToString()  // Pārdefinēta metode ToString(), lai atgrieztu visu īpašību vērtības kā tekstu
        {
            return $"AssignedAt: {AssignedAt}; Support: {Support?.ToString() ?? "<null>"}; Ticket: {Ticket?.ToString() ?? "<null>"}; Comment: {Comment ?? "<null>"}; ";
        }
    }
}
