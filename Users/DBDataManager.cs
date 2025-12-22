using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;
using Microsoft.EntityFrameworkCore;

namespace User
{
    public class DBDataManager : IDataManager
    {
        public ObjectAddManager oam { get; set; }
        public UserContext uc { get; set; }

        public DBDataManager()
        {
            uc = new UserContext();
            oam = new ObjectAddManager(uc);
        }

        public void createTestData()
        {
            var employee = new Employee
            {
                UserID = 1,
                UserName = "Māris Priede",
                Email = "priedemaris5@gmail.com",
                IsActive = true,
                ContractDate = new DateTime(2020, 5, 1)
            };
            uc.Employees.Add(employee);

            var danielsEmployee = new Employee
            {
                UserID = 2,
                UserName = "Daniels Briedis",
                Email = "burunduks234@gmail.com",
                IsActive = true,
                ContractDate = DateTime.Today
            };
            uc.Employees.Add(danielsEmployee);

            var itSupport = new ITSupport(danielsEmployee, SpecializationType.Network);
            uc.ITSupports.Add(itSupport);

            uc.ITSupports.Add(new ITSupport("Zane", "zanegraav@gmail.com", 2, true, SpecializationType.Network));

            var ticket = new Ticket
            {
                TicketId = 101,
                Title = "Nevar savienoties ar VPN",
                Description = "Lietotājs nevar savienoties ar kompānijas VPN no mājām",
                Priority = 2,
                CreatedBy = employee,
                Status = TicketStatus.Open,
                IsResolved = false
            };
            uc.Tickets.Add(ticket);

            uc.Assignements.Add(new Assignement
            {
                AssignedAt = DateTime.Now,
                Support = itSupport,
                Ticket = ticket,
                Comment = "Sākotnējais pienākums — tīkla speciālists."
            });

            oam.Save();
        }

        public string Print()
        {
            var result = new StringBuilder();

            result.AppendLine("=== EMPLOYEES ===");
            foreach (var e in uc.Employees) result.AppendLine(e.ToString());

            result.AppendLine("=== SUPPORTS ===");
            foreach (var s in uc.ITSupports) result.AppendLine(s.ToString());

            result.AppendLine("=== TICKETS ===");
            foreach (var t in uc.Tickets) result.AppendLine(t.ToString());

            result.AppendLine("=== ASSIGNMENTS ===");
            foreach (var a in uc.Assignements) result.AppendLine(a.ToString());

            return result.ToString();
        }

        public void Load(string path)
        {
            _ = path;
            try
            {
                // Reload the context to ensure fresh data
                uc = new UserContext();
                // Recreate ObjectAddManager with the refreshed context
                oam = new ObjectAddManager(uc);

                // Force-load entities if using lazy-loading off
                _ = uc.Employees.ToList();
                _ = uc.ITSupports.ToList();
                _ = uc.Tickets.ToList();
                _ = uc.Assignements
                    .Include(a => a.Support)
                    .Include(a => a.Ticket)
                    .ToList();

                // If objList should reflect a combined list, rebuild it
                // Assuming ObjectAddManager builds objList from the context; if not, do:
                // oam.objList.Clear();
                // oam.objList.AddRange(uc.Employees);
                // oam.objList.AddRange(uc.ITSupports);
                // oam.objList.AddRange(uc.Tickets);
                // oam.objList.AddRange(uc.Assignements);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Save(string path)
        {
            _ = path; // lai izvairītos no brīdinājuma par neizmantotu mainīgo
            try
            {
                uc.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void reset()
        {
            try
            {
                uc.Employees.RemoveRange(uc.Employees);
                uc.ITSupports.RemoveRange(uc.ITSupports);
                uc.Tickets.RemoveRange(uc.Tickets);
                uc.Assignements.RemoveRange(uc.Assignements);
                uc.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
        }
    }
}
