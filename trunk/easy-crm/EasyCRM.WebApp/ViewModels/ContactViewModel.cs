using System;
using System.Linq;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using System.Collections.Generic;


namespace EasyCRM.WebApp.ViewModels
{
    public class ContactViewModel
    {

        public Contact Contact { get; set; }
        public SelectList Statuses { get; set; }


        public ContactViewModel()
            : this(new Contact())
        {
        }

        public ContactViewModel(Contact contact)
        {
            //creating the elements for contact status and contact priority drop down lists
            var statuses = Enum.GetNames(typeof(ContactStatus));

            Contact = contact;
            Statuses = new SelectList(statuses, Contact.Status);
        }
    }
}