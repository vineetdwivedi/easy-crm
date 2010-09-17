using System.ComponentModel;
using System.Web.Mvc;

namespace EasyCRM.WebApp.ViewModels
{
    public class AddTaskViewModel
    {
        [DisplayName("Task")]
        public string TaskId { get; set; }

        public SelectList Tasks { get; set; }

    }

}