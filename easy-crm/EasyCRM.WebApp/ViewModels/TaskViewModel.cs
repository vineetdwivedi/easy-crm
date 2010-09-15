using System;
using System.Linq;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using System.Collections.Generic;


namespace EasyCRM.WebApp.ViewModels
{
    public class TaskViewModel
    {

        public Task Task { get; set; }
        public SelectList Statuses { get; set; }
        public SelectList Priorities { get; set; }

        public TaskViewModel()
        {
            //we round the current time like this: 13:45:0 ==> 14:00:00
            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                            (DateTime.Now.Hour + 1) % 24, 0, 0);

            Task = new Task
            {
                StartDate = current,
                LimitDate = current.AddDays(5),
                EndDate = current.AddDays(10)
            };

            //creating the elements for task status and task priority drop down lists
            List<string> statuses = new List<string>(Enum.GetNames(typeof(TaskStatus)));
            List<string> priorities = new List<string>(Enum.GetNames(typeof(TaskPriority)));

            Statuses = new SelectList(statuses, Task.Status);
            Priorities = new SelectList(priorities, Task.Priority);
        }

        public TaskViewModel(Task task)
        {
            //creating the elements for task status and task priority drop down lists
            List<string> statuses = new List<string>(Enum.GetNames(typeof(TaskStatus)));
            List<string> priorities = new List<string>(Enum.GetNames(typeof(TaskPriority)));

            Task = task;
            Statuses = new SelectList(statuses, Task.Status);
            Priorities = new SelectList(priorities, Task.Priority);
        }
    }
}