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
            : this(new Account())
        {
        }

        public AccountViewModel(Account account)
        {
            //creating the elements for account type dropdown list
            var types = Enum.GetNames(typeof(AccountType));

            Account = account;
            Types = new SelectList(types, Account.Type);
        }
    }
}
