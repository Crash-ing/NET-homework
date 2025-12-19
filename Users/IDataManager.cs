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
        void Save(string path);
        void Load(string path);
        void createTestData();
        void reset();
    }
}
