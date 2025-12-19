using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace User
{
    public enum TicketStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }
    public class Ticket
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int TicketId { get; set; }
        public Employee CreatedBy { get; set; }
        public TicketStatus Status { get; set; }
        public bool IsResolved { get; set; }

        public override string? ToString()  // Pārdefinēta metode ToString(), lai atgrieztu visu īpašību vērtības kā tekstu
        {
            return $"Title: {Title}; Description: {Description}; Priority: {Priority}; TicketId: {TicketId}; CreatedBy: {CreatedBy}; Status: {Status}; IsResolved: {IsResolved};";
        }   
    }
}
