using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    internal static class controller
    {
        static public string taskList;
        static public Project project;
        public static void Run()
        {
            project = view.ProjectCreation();
            if (view.AskPreload()) Preload.load(project);
            MenuLoop();
        }
        public static void MenuLoop()
        {
            taskList = project.GetTaskList();
            switch (view.Menu())
            {
                case "project info":
                case "1":
                    view.CaseHeader("Project info");
                    Console.WriteLine($"Current tasks in project: {taskList}");
                    ShowMembers();
                    view.CaseFooter("");
                    break;
                case "add task":
                case "2":
                    view.CaseHeader("Add task");
                    project.AddTask(
                        view.AskTaskName(),
                        DateTime.Now,
                        view.AskInfo("Enter task description: ")
                        );
                    view.CaseFooter("Task added");
                    break;
                case "change task name":
                case "3":
                    view.CaseHeader("Change task name");
                    project.ChangeTaskName(
                        view.AskTaskName(),
                        view.AskInfo("Enter new task name: ")
                        );
                    view.CaseFooter("Task name changed");
                    break;
                case "change task description":
                case "4":
                    view.CaseHeader("Change task description");
                    project.ChangeTaskDescription(
                        view.AskTaskName(),
                        view.AskInfo("Enter new task description: ")
                        );
                    view.CaseFooter("Task description changed");
                    break;
                case "add member to task":
                case "5":
                    view.CaseHeader("Add member to task");
                    project.AddMemberToTask(
                        view.AskTaskName(),
                        view.AskInfo("Enter member name: "),
                        Convert.ToInt32(view.AskInfo("Enter member age: ")),
                        view.AskInfo("Enter member sex: "),
                        DateTime.Now
                        );
                    view.CaseFooter("Member added to task");
                    break;
                case "modify task member":
                case "6":
                    view.CaseHeader("Modify task member");
                    project.ModTaskMember(
                        view.AskTaskNameWMembers(),
                        view.AskInfo("Enter member name: "),
                        view.AskInfo("Enter new name: "),
                        Convert.ToInt32(view.AskInfo("Enter new age: ")),
                        view.AskInfo("Enter new sex: ")
                        );
                    view.CaseFooter("Task member modified");
                    break;
                case "retire task member":
                case "7":
                    view.CaseHeader("Retire task member");
                    project.RetireTaskMember(
                        view.AskTaskNameWMembers(),
                        view.AskInfo("Enter member name: "),
                        DateTime.Now
                        );
                    view.CaseFooter("Task member retired");
                    break;
                case "close task":
                case "8":
                    view.CaseHeader("Close task");
                    project.EndTask(
                        view.AskTaskName(),
                        DateTime.Now
                        );
                    view.CaseFooter("Task closed");
                    break;
                case "exit":
                case "9":
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong option");
                    view.PressToContinue();
                    MenuLoop();
                    break;
            }
        }
        public static void ShowMembers()
        {
            if (view.AskInfo("Show members in task? (y/n): ") == "y")
            {
                string taskName = view.AskInfo("Enter task name: ");
                Console.WriteLine($"Current members in task {taskName}: {project.GetMembersInTask(taskName)}");
                ShowMemberInfo(taskName);
                ShowMembers();
            }
        }
        public static void ShowMemberInfo(string taskName)
        {
            if (view.AskInfo("See member info? (y/n)") == "y")
            {
                Console.WriteLine(project.GetMemberInfo(taskName, view.AskInfo("Enter member name: ")));
                ShowMemberInfo(taskName);
            }
        }
    }
}
