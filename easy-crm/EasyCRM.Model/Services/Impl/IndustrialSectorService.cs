using System.Collections.Generic;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Repositories;
using EasyCRM.Model.Repositories.Entity;

namespace EasyCRM.Model.Services.Impl
{
    public class IndustrialSectorService : IIndustrialSectorService
    {
        private IValidationDictionary _validationDictionary;
        private IIndustrialSectorRepository _repository;


        public IndustrialSectorService(IValidationDictionary validationDictionary)
            : this(validationDictionary, new EntityIndustrialSectorRepository())
        { }


        public IndustrialSectorService(IValidationDictionary validationDictionary, IIndustrialSectorRepository repository)
        {
            _validationDictionary = validationDictionary;
            _repository = repository;
        }


        public bool ValidateIndustrialSector(IndustrialSector sectorToValidate)
        {

            if (sectorToValidate.Sector.Trim().Length == 0)
                _validationDictionary.AddError("Sector", "Sector is required.");
            return _validationDictionary.IsValid;
        }


        #region IIndustrialSectorService Members

        public bool CreateIndustrialSector(IndustrialSector sectorToCreate)
        {
            // Validation logic
            if (!ValidateIndustrialSector(sectorToCreate))
                return false;

            // Database logic
            try
            {
                _repository.Create(sectorToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditIndustrialSector(IndustrialSector sectorToEdit)
        {
            // Validation logic
            if (!ValidateIndustrialSector(sectorToEdit))
                return false;

            // Database logic
            try
            {
                _repository.Update(sectorToEdit);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteIndustrialSector(IndustrialSector sectorToDelete)
        {
            try
            {
                _repository.Delete(sectorToDelete);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IndustrialSector GetIndustrialSector(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<IndustrialSector> ListIndustrialSectors()
        {
            return _repository.ListAll();
        }

        #endregion

    }
}
