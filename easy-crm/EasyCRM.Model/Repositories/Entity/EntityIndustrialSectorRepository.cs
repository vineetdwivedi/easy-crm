using System.Collections.Generic;
using System.Linq;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories.Entity
{
    public class EntityIndustrialSectorRepository : IIndustrialSectorRepository
    {
        private EasyCRMDBEntities _entities = EntityRepository.GetEntities();

        #region IIndustrialSectorRepository Members
        public IndustrialSector Create(IndustrialSector sectorToCreate)
        {
            _entities.AddToIndustrialSectorSet(sectorToCreate);
            _entities.SaveChanges();
            return sectorToCreate;

        }

        public void Delete(IndustrialSector sectorToDelete)
        {
            var originalIndustrialSector = Get(sectorToDelete.Id);
            _entities.DeleteObject(originalIndustrialSector);
            _entities.SaveChanges();

        }

        public IndustrialSector Update(IndustrialSector sectorToUpdate)
        {
            var originalIndustrialSector = Get(sectorToUpdate.Id);
            _entities.ApplyCurrentValues(originalIndustrialSector.EntityKey.EntitySetName, sectorToUpdate);
            _entities.SaveChanges();
            return sectorToUpdate;

        }

        public IndustrialSector Get(int id)
        {
            return _entities.IndustrialSectorSet.First(sector => sector.Id == id);
        }

        public IEnumerable<IndustrialSector> ListAll()
        {
            return _entities.IndustrialSectorSet.ToList();
        } 
        #endregion
    }
}
