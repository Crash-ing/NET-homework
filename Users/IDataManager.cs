using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public interface IDataManager
    {
        string Print();
        void Save(string path = null);
        void Load(string path = null);
        void createTestData();
        void reset();
    }
}
