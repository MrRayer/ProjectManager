using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    internal class Member
    {
        public Person person { get; set; }
        public DateTime startTime { get; set; }
        public string status { get; set; }
        public DateTime endTime { get; set; }
        // -----   Constructor  -----
        public Member(string personName,int personAge,string personSex,DateTime IstartTime)
        {
            person = new Person(personName, personAge, personSex);
            startTime = IstartTime;
            status = "Working";
        }
        // -----   Constructor  -----
        public void End(DateTime IendTime)
        {
            endTime = IendTime;
            status = "Finished";
        }
        public bool IsActive()
        {
            if (status == "Working") return true;
            else return false;
        }
    }
}
