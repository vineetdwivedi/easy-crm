using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EasyCRM.WebApp.ViewModels
{
    public class AddTaskViewModel
    {
        [DisplayName("Task")]
        public int TaskId { get; set; }
       
        public SelectList Tasks { get; set; }

        [ScaffoldColumn(false)]
        public int AccountId { get; set; } //useful to go back to the account details from the add task page

    }

}