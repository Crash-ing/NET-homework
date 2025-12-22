using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class ObjectCollection
    {
        public ObjectCollection() {
            objList = new List<Object>();
        }

        List<Object> objList;

        public List<Object> ObjList { get => objList; set => objList = value; }

    }
}
