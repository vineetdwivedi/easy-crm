using System;
using System.Linq;
using System.Web.Mvc;
using EasyCRM.Model.Domains;


namespace EasyCRM.WebApp.ViewModels
{
    public class TaskViewModel
    {

        public Task Task { get; set; }
        public SelectList Statuses { get; set; }
        public SelectList Priorities { get; set; }

        public TaskViewModel()
        {
        }

        public TaskViewModel(Task task)
        { 
            Task = task;

            //creating the elements for task status and task priority drop down lists
            var statuses = from TaskStatus s in Enum.GetValues(typeof(TaskStatus))
                           select new { ID = s, Name = s.ToString() };

            var priorities = from TaskPriority s in Enum.GetValues(typeof(TaskPriority))
                             select new { ID = s, Name = s.ToString() };

           
            Statuses = new SelectList(statuses, "ID", "Name", task.Status);
            Priorities = new SelectList(priorities, "ID", "Name", task.Priority);


        }
    }
}