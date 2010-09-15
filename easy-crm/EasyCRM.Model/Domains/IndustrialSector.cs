using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyCRM.Model.Domains
{
    [MetadataType(typeof(IndustrialSectorMetaData))]
    public partial class IndustrialSector
    {
        // Validation rules for the IndustrialSector class
        public class IndustrialSectorMetaData
        {
            [ScaffoldColumn(false)]
            public object Id { get; set; }

            [Required(ErrorMessage = "A Sector is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Sector { get; set; }

                     
        }
    }


}
