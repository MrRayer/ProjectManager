using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    internal static class view
    {

        public static void PressToContinue()
        {
            Console.Write("Press a key to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static Project ProjectCreation() // ---------- Create Project ----------
        {
            Console.WriteLine("Welcome to the Project manager");
            Console.Write("Enter the name of the project: ");
            string projectName = Console.ReadLine();
            Project project = new Project(projectName);
            Console.WriteLine($"Your project {projectName} has been created");
            return project;
        }
        public static bool AskPreload() // ---------- Preload ----------
        { 
            Console.Write("Preload data? (y/n)");
            if (Console.ReadLine() == "y") return true;
            else return false;
        }
        public static string Menu() // ---------- Menu ----------
        {
            Console.Clear();
            Console.WriteLine("Chose an action:");
            Console.WriteLine("(1)  Show project info");
            Console.WriteLine("(2)  Add task");
            Console.WriteLine("(3)  Change task name");
            Console.WriteLine("(4)  Change task description");
            Console.WriteLine("(5)  Add member to task");
            Console.WriteLine("(6)  Modify task member");
            Console.WriteLine("(7)  Retire task member");
            Console.WriteLine("(8)  Close task");
            Console.WriteLine("(9)  To exit");
            return Console.ReadLine();
        }
        public static string AskInfo(string message) // ---------- Question ----------
        {
            Console.Write(message);
            string taskName = Console.ReadLine();
            return taskName;
        }
        public static void CaseHeader(string message)
        {
            Console.Clear();
            Console.WriteLine($"Selected: {message}");
        }
        public static void CaseFooter(string message)
        {
            Console.WriteLine(message);
            PressToContinue();
            controller.MenuLoop();
        }
        public static string AskTaskName()
        {
            Console.WriteLine($"Current tasks in project: {controller.taskList}");
            string taskName = AskInfo("Enter task name: ");
            return taskName;
        }
        public static string AskTaskNameWMembers()
        {
            Console.WriteLine($"Current tasks in project: {controller.taskList}");
            string taskName = AskInfo("Enter task name: ");
            Console.WriteLine($"Current members in task {taskName}: {controller.project.GetMembersInTask(taskName)}");
            return taskName;
        }
    }
}
