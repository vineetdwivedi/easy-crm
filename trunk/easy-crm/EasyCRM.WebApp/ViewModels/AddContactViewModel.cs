using System.ComponentModel;
using System.Web.Mvc;

namespace EasyCRM.WebApp.ViewModels
{
    public class AddContactViewModel
    {
        [DisplayName("Contact")]
        public string ContactId { get; set; }

        public SelectList Contacts { get; set; }

    }

}