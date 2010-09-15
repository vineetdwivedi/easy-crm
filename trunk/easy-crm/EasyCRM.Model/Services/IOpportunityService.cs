using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface IOpportunityService
    {
        bool CreateOpportunity(Opportunity opportunityToCreate);
        bool DeleteOpportunity(Opportunity opportunityToDelete);
        bool EditOpportunity(Opportunity opportunityToEdit);
        Opportunity GetOpportunity(int id);
        IEnumerable<Opportunity> ListOpportunities();

    }
}
