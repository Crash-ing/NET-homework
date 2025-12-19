using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Users;

// interfeisa implementācija

namespace User
{
    public class FigureXMLDataManager : IDataManager
    {
        private readonly string _path;      // noklusētais ceļš saglabāšanai/ielādei
        public DataStore Store { get; set; } = new();

        public FigureXMLDataManager()
        {
            Store = new DataStore();
        }

        public FigureXMLDataManager(string path)
        {
            _path = path;
        }

        public string Print()   // drukāšanas metode
        {
            var result = new StringBuilder();   // par StringBuilder uzzināju no ChatGPT
                                                // padara efektīvāku teksta veidošanu, nav jāizmanto, piemēram, result = result + "teksts"

            result.AppendLine("=== EMPLOYEES ===");
            foreach (var e in Store.Employees) result.AppendLine(e.ToString());

            result.AppendLine("=== SUPPORTS ===");
            foreach (var s in Store.ITSupports) result.AppendLine(s.ToString());

            result.AppendLine("=== TICKETS ===");
            foreach (var t in Store.Tickets) result.AppendLine(t.ToString());

            result.AppendLine("=== ASSIGNMENTS ===");
            foreach (var a in Store.Assignements) result.AppendLine(a.ToString());

            return result.ToString();   // atgriež kā cilvēkam lasāmu tekstu
        }
        public void Save(string path = null)    // saglabāšana XML formātā
        {
            if (string.IsNullOrWhiteSpace(path))    // ja nav padots ceļš, tad izmanto noklusēto
                path = _path;

            var serializer = new XmlSerializer(typeof(DataStore));  // Izveido XML serializatoru priekš DataStore objekta

            using (var fs = new FileStream(path, FileMode.Create))  // Izmanto FileStream, lai rakstītu failā
            {
                serializer.Serialize(fs, Store);    // pārvērš DataStore objektu XML formātā un ieraksta failā
            }

            Console.WriteLine($"Dati saglabāti failā: {path}");
        }
        public void Load(string path = null)
        {
            if (string.IsNullOrWhiteSpace(path))    // ja nav padots ceļš, tad izmanto noklusēto
                path = _path;

            if (!File.Exists(path))   // pārbauda vai fails eksistē
            {
                Console.WriteLine("Fails nav atrasts!");
                return;
            }

            var serializer = new XmlSerializer(typeof(DataStore));

            using (var fs = new FileStream(path, FileMode.Open))   // Izmanto FileStream, lai lasītu no faila
            {
                Store = (DataStore)serializer.Deserialize(fs);   // nolasīto XML pārvērš atpakaļ DataStore objektā
            }

            Console.WriteLine($"Dati ielādēti no: {path}");
        }
        public void createTestData()
        {
            Store.Employees.Add(new Employee
            {
                UserID = 1,
                UserName = "Māris Priede",
                Email = "priedemaris5@gmail.com",
                IsActive = true,
                ContractDate = new DateTime(2020, 5, 1)
            });

            Store.ITSupports.Add(new ITSupport("Zane", "zanegraav@gmail.com", 2, true, SpecializationType.Network));

            Store.Tickets.Add(new Ticket
            {
                TicketId = 101,
                Title = "Nevar savienoties ar VPN",
                Description = "Lietotājs nevar savienoties ar kompānijas VPN no mājām",
                Priority = 2,
                CreatedBy = Store.Employees[0],
                Status = TicketStatus.Open,
                IsResolved = false
            });

            Store.Assignements.Add(new Assignement
            {
                AssignedAt = DateTime.Now,
                Support = Store.ITSupports[0],
                Ticket = Store.Tickets[0],
                Comment = "Sākotnējais pienākums — tīkla speciālists."

            });
        }
        public void reset()
        {
            Store = new DataStore();
        }

        public void Add(Assignement assignement)
        {
            Store.Assignements.Add(assignement);
        }
    }
}
