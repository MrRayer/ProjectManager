using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    internal static class Preload
    {

        public static void load(Project project)
        {
            project.AddTask("testtask1",new DateTime(2022,7,1,12,0,0), "Task preloaded to test the Project Manager");
            project.AddMemberToTask("testtask1", "Pepe", 40, "m", new DateTime(2022, 7, 1, 12, 0, 0));
            project.AddMemberToTask("testtask1", "Gonzalo", 25, "m", new DateTime(2022, 7, 1, 14, 0, 0));
            project.AddMemberToTask("testtask1", "Laura", 30, "f", new DateTime(2022, 7, 1, 16, 0, 0));
            project.RetireTaskMember("testtask1", "Gonzalo", new DateTime(2022, 7, 1, 18, 0, 0));
            project.AddTask("testtask2", new DateTime(2022,7,1,12,0,0), "Task preloaded to test the Project Manager");
            project.AddMemberToTask("testtask2", "Jose", 41, "m", new DateTime(2022, 7, 1, 12, 0, 0));
            project.AddMemberToTask("testtask2", "Paula", 22, "f", new DateTime(2022, 7, 1, 15, 0, 0));
            project.AddMemberToTask("testtask2", "Pablo", 31, "m", new DateTime(2022, 7, 1, 18, 0, 0));
            project.RetireTaskMember("testtask2", "Paula", new DateTime(2022, 7, 1, 16, 0, 0));
            project.AddTask("testtask3", new DateTime(2022, 7, 1, 14, 0, 0), "Task preloaded to test the Project Manager");
            project.AddMemberToTask("testtask3", "Teresa", 39, "f", new DateTime(2022, 7, 1, 14, 0, 0));
            project.AddMemberToTask("testtask3", "Roberto", 53, "m", new DateTime(2022, 7, 1, 15, 0, 0));
            project.AddMemberToTask("testtask3", "Rocio", 28, "f", new DateTime(2022, 7, 1, 18, 0, 0));
            project.RetireTaskMember("testtask3", "Gonzalo", new DateTime(2022, 7, 1, 19, 0, 0));
        }
    }
}
