using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    internal class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string sex { get; set; }

        public Person(string Iname, int Iage, string Isex)
        {
            name = Iname;
            age = Iage;
            sex = Isex;            
        }
        public void Update(string Iname, int Iage, string Isex)
        {
            if (Iname != "N/A") name = Iname;
            if (Iage > 0) age = Iage;
            if (Iname != "N/A") sex = Isex;
        }
        public bool NameCheck(string Iname)
        {
            if (Iname == name) return true;
            else return false;
        }

    }
}
