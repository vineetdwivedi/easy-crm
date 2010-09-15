using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories.Entity
{
    /// <summary>
    /// We use a singleton pattern to retrieve the SAME entities' context use inside  all our
    /// repository classes. Otherwise, the EF fails with this error while trying to save an object: 
    /// “An entity object cannot be referenced by multiple instances of IEntityChangeTracker”
    /// </summary>
    public class EntityRepository
    {
        private static EasyCRMDBEntities _entities = null;

        public static EasyCRMDBEntities GetEntities()
        {
            if (_entities == null)
                _entities = new EasyCRMDBEntities();

            return _entities;
        }
    }
}
