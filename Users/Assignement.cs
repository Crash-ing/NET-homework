using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace User
{
    public class Assignement
    {
        public DateTime AssignedAt { get; set; }
        public ITSupport? Support { get; set; }    // allow null because assignments can be created before selection
        public Ticket? Ticket { get; set; }       // allow null to avoid CS8618
        public string? Comment { get; set; }      // nullable comment
        public override string? ToString()  // Pārdefinēta metode ToString(), lai atgrieztu visu īpašību vērtības kā tekstu
        {
            return $"AssignedAt: {AssignedAt}; Support: {Support?.ToString() ?? "<null>"}; Ticket: {Ticket?.ToString() ?? "<null>"}; Comment: {Comment ?? "<null>"}; ";
        }
    }
}
