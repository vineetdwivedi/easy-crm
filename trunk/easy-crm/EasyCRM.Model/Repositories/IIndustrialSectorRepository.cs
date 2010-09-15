using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories
{
    public interface IIndustrialSectorRepository
    {
        IndustrialSector Create(IndustrialSector sectorToCreate);
        void Delete(IndustrialSector sectorToDelete);
        IndustrialSector Update(IndustrialSector sectorToUpdate);
        IndustrialSector Get(int id);
        IEnumerable<IndustrialSector> ListAll();

    }
}
