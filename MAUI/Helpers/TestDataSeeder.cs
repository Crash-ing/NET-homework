//using System;
//using Users;
//using User;
//using MAUI.Forms.AddItemsForms;

//namespace MAUI.Helpers
//{
//    public static class TestDataSeeder
//    {
//        // Seed AppData.Instance with the same sample data you used elsewhere.
//        public static void SeedIfEmpty()
//        {
//            var store = AppData.Instance;   //

//            if (store.Employees.Count == 0)
//            {
//                store.Employees.Add(new Employee
//                {
//                    UserID = 1,
//                    UserName = "Māris Priede",
//                    Email = "priedemaris5@gmail.com",
//                    IsActive = true,
//                    ContractDate = new DateTime(2020, 5, 1)
//                });
//            }

//            if (store.ITSupports.Count == 0)
//            {
//                store.ITSupports.Add(new ITSupport("Zane", "zanegraav@gmail.com", 2, true, SpecializationType.Network));
//            }

//            if (store.Tickets.Count == 0)
//            {
//                store.Tickets.Add(new Ticket
//                {
//                    TicketId = 101,
//                    Title = "Nevar savienoties ar VPN",
//                    Description = "Lietotājs nevar savienoties ar kompānijas VPN no mājām",
//                    Priority = 2,
//                    CreatedBy = store.Employees.Count > 0 ? store.Employees[0] : null!,
//                    Status = TicketStatus.Open,
//                    IsResolved = false
//                });
//            }

//            if (store.Assignements.Count == 0 && store.ITSupports.Count > 0 && store.Tickets.Count > 0)
//            {
//                store.Assignements.Add(new Assignement
//                {
//                    AssignedAt = DateTime.Now,
//                    Support = store.ITSupports[0],
//                    Ticket = store.Tickets[0],
//                    Comment = "Sākotnējais pienākums — tīkla speciālists."
//                });
//            }
//        }
//    }
//}