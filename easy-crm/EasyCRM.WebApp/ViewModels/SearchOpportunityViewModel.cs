using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EasyCRM.Model.Domains;

namespace EasyCRM.WebApp.ViewModels
{
    public class SearchOpportunityViewModel
    {
        public string Status { get; set; }

        public SelectList Statuses { get; set; }

        public SearchOpportunityViewModel()
        {
            //creating the elements for opportunity status and opportunity priority drop down lists
            List<string> statuses = new List<string>(Enum.GetNames(typeof(OpportunityStatus)));

            //default value
            statuses.Insert(0, "");

            Statuses = new SelectList(statuses, "");
        }
    }

}