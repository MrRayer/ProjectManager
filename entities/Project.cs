using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    internal class Project
    {
        string name { get; set; }
        private DateTime startTime { get; set; }
        private List<Task> tasks = new List<Task>();

        // -----  Constructor   -----
        public Project(string Iname)
        {
            name = Iname;
        }
        // -----  Constructor   -----
        // -----  Manage tasks  -----
            // -----   Add/Remove   -----
        public void AddTask(string Iname,DateTime IstartTime,string Idescription = "N/A") 
        {
            tasks.Add(new Task(Iname, IstartTime, Idescription));
        }
        public void EndTask(string taskName,DateTime endTime)
        {
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskName))
                {
                    foreach (Member member in task.members)
                    {
                        if (member.IsActive()) RetireTaskMember(taskName, member.person.name, endTime);
                    }
                    task.endTime = endTime;
                    task.status = "Ended";
                }
            }
        }
            // -----   Add/Remove   -----
            // -----    Mod task    -----
        public void ChangeTaskName(string taskToMod, string newName)
        {
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskToMod))
                {
                    task.name = newName;
                }
            }
        }
        public void ChangeTaskDescription(string taskToMod, string newDescription)
        {
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskToMod))
                {
                    task.description = newDescription;
                }
            }
        }
            // -----    Mod task    -----
            // ----- Mod taskmembs  -----
        public void AddMemberToTask(string taskToMod, string name, int age, string sex, DateTime startTime)
        {
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskToMod))
                {
                    if (task.status == "In progress")
                    {
                        task.members.Add(new Member(name, age, sex, startTime));
                    }
                    else { Console.WriteLine("Can not add member to task that is not in progress"); }
                }
            }
        }
        public void ModTaskMember(string taskToMod,string oldName, string name, int age, string sex)
        {
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskToMod))
                {
                    if (task.status == "In progress")
                    {
                        foreach (Member member in task.members)
                        {
                            if (member.person.NameCheck(oldName)) member.person.Update(name, age, sex);
                        }
                    }
                    else { Console.WriteLine("Can not modify member if task is not in progress"); }
                }
            }
        }
        public void RetireTaskMember(string taskToMod, string name, DateTime retireTime)
        {
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskToMod))
                {
                    if (task.status == "In progress")
                    {
                        foreach (Member member in task.members)
                        {
                            if (member.person.NameCheck(name)) member.End(retireTime);
                        }
                    }
                    else { Console.WriteLine("Can not retire member if task is not in progress"); }
                }
            }
        }
            // ----- Mod taskmembs  -----
        // -----  Manage tasks  -----
        // -----   ui Methods   -----
        public string GetTaskList()
        {
            string taskList = "";
            foreach (Task task in tasks)
            {
                if (taskList != "") taskList += ", ";
                taskList += task.name;
            }

            return taskList;
        }
        public string GetMembersInTask(string taskName)
        {
            string membersList = "Members[";
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskName))
                {
                    foreach (Member member in task.members)
                    {
                        if (membersList != "Members[") membersList += ", ";
                        membersList += member.person.name;
                    }
                    membersList += $"], task description: [{task.description}], task status: {task.status}";
                    if (task.status == "In progress") { membersList += $", time since start: {DateTime.Now.Subtract(task.startTime)}"; }
                    if (task.status == "Ended") { membersList += $", total time : {task.endTime.Subtract(task.startTime)}"; }
                    return membersList;
                }
            }
            return "wrong task name";
        }
        public string GetMemberInfo(string taskName, string memberName)
        {
            foreach (Task task in tasks)
            {
                if (task.NameCheck(taskName))
                    foreach(Member member in task.members)
                    {
                        if (member.person.name == memberName)
                        {
                            string personInfo = $"name: {member.person.name}, age: {member.person.age}, sex: {member.person.sex}, status: {member.status}";
                            if (member.status == "Working") { personInfo += $", time worked: {DateTime.Now.Subtract(member.startTime)}"; }
                            if (member.status == "Finished") { personInfo += $", time worked: {member.endTime.Subtract(member.startTime)}"; }
                            return personInfo;
                        }
                    }
            }
            return $"{memberName} not found";
        }
        // -----   ui Methods   -----
    }
}
