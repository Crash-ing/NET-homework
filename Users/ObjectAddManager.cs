using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace User
{
    public class ObjectAddManager : IAddObject, IRemove
    {
        public UserContext uc { get; set; }

        public List<Object> objList
        {
            get
            {
                var obj = new List<Object>();
                    obj = obj.Union(uc.Employees.ToList())
                    .Union(uc.ITSupports.ToList())
                    .Union(uc.Tickets.ToList())
                    .Union(uc.Assignements.ToList())
                    .ToList();

                Debug.WriteLine(obj.Count);
                return obj;
            }
        }

        public ObjectAddManager(UserContext _uc)
        {
            uc = _uc;
        }

        public void Add(Object obj)
        {
            try
            {
                if (obj is Employee)
                {
                    uc.Employees.Add((Employee)obj);
                }
                else if (obj is ITSupport)
                {
                    uc.ITSupports.Add((ITSupport)obj);
                }
                else if (obj is Ticket)
                {
                    uc.Tickets.Add((Ticket)obj);
                }
                else if (obj is Assignement)
                {
                    uc.Assignements.Add((Assignement)obj);
                }
                else
                {
                    return;
                }
                uc.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public bool Remove(Object obj)
        {
            try
            {
                if (obj is Employee)
                {
                    uc.Employees.Remove((Employee)obj);
                }
                else if (obj is ITSupport)
                {
                    uc.ITSupports.Remove((ITSupport)obj);
                }
                else if (obj is Ticket)
                {
                    uc.Tickets.Remove((Ticket)obj);
                }
                else if (obj is Assignement)
                {
                    uc.Assignements.Remove((Assignement)obj);
                }
                else
                {
                    return false;
                }
                uc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public void Save()
        {
            uc.SaveChanges();
        }
    }
}
