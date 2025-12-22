using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;

namespace MAUI
{
    public static class AppData     // klase datu glabāšanai starp lapām
    {
        // public static DataStore Instance = new DataStore();
        public static DBDataManager Instance = new DBDataManager();
    }
}
