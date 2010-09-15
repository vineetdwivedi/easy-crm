using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface IIndustrialSectorService
    {
        bool CreateIndustrialSector(IndustrialSector sectorToCreate);
        bool DeleteIndustrialSector(IndustrialSector sectorToDelete);
        bool EditIndustrialSector(IndustrialSector sectorToEdit);
        IndustrialSector GetIndustrialSector(int id);
        IEnumerable<IndustrialSector> ListIndustrialSectors();

    }
}
