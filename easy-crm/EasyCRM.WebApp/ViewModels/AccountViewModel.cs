using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCRM.Model.Domains;
using System.Web.Mvc;

namespace EasyCRM.WebApp.ViewModels
{
    public class AccountViewModel
    {
        public Account Account { get; set; }
        public int SectorId { get; set; }


        public SelectList Types { get; set; }
        public SelectList Sectors { get; set; }

        public AccountViewModel()
        {
            //creating the elements for account type dropdown
            var types = Enum.GetNames(typeof(AccountType));

            Types = new SelectList(types, "");
        }
    }
}
