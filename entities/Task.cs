using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    internal class Task
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startTime { get; set; }
        public List<Member> members = new List<Member>();
        public string status { get; set; }
        public DateTime endTime { get; set; }

        // -----   Constructor  -----
        public Task(string Iname, DateTime IstartTime, string Idescription)
        {
            name = Iname;
            description = Idescription;
            startTime = IstartTime;
            status = "In progress";
        }
        // -----   Constructor  -----
        // ----- Get task info  -----
        public bool NameCheck(string Iname)
        {
            if (name == Iname) return true;
            else return false;
        }
        // ----- Get task info  -----
    }
}