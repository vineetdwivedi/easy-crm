using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        IEnumerable<Opportunity> ListAllByCriteria(Expression<Func<Opportunity, bool>> predicate);
    }
}
