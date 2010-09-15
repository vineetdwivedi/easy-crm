using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories
{
    public interface IOpportunityRepository
    {
        Opportunity Create(Opportunity opportunityToCreate);
        void Delete(Opportunity opportunityToDelete);
        Opportunity Update(Opportunity opportunityToUpdate);
        Opportunity Get(int id);
        IEnumerable<Opportunity> ListAll();

    }
}
