using System;
using System.Linq;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using System.Collections.Generic;


namespace EasyCRM.WebApp.ViewModels
{
    public class OpportunityViewModel
    {

        public Opportunity Opportunity { get; set; }
        public int AccountId { get; set; }

        public SelectList Statuses { get; set; }
        public SelectList Accounts { get; set; }


        public OpportunityViewModel()
            : this(new Opportunity())
        {
        }

        public OpportunityViewModel(Opportunity opportunity)
        {
            //creating the elements for opportunity status drop down list
            var statuses = Enum.GetNames(typeof(OpportunityStatus));

            Opportunity = opportunity;
            Statuses = new SelectList(statuses, Opportunity.Status);

        }
    }
}