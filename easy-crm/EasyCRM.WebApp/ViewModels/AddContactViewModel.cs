using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EasyCRM.WebApp.ViewModels
{
    public class AddContactViewModel
    {
        [DisplayName("Contact")]
        public int ContactId { get; set; }

        public SelectList Contacts { get; set; }

        [ScaffoldColumn(false)]
        public int AccountId { get; set; } //useful to go back to the account details from the add contact page

    }

}