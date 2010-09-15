using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyCRM.Model.Domains;

namespace EasyCRM.WebApp.ViewModels
{
    public class SearchTaskViewModel
    {
        public string Status { get; set; }
        public string Priority { get; set; }


        public SelectList Statuses { get; set; }
        public SelectList Priorities { get; set; }

        public SearchTaskViewModel()
        {

            //creating the elements for task status and task priority drop down lists
            List<string> statuses = new List<string>(Enum.GetNames(typeof(TaskStatus)));
            List<string> priorities = new List<string>(Enum.GetNames(typeof(TaskPriority)));

            //default values
            statuses.Insert(0, "");
            priorities.Insert(0, "");

            Statuses = new SelectList(statuses, "");
            Priorities = new SelectList(priorities, "");


        }
    }

}