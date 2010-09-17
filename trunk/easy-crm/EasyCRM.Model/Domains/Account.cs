using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyCRM.Model.Domains
{
    [MetadataType(typeof(AccountMetaData))]
    public partial class Account
    {
        // Validation rules for the Account class
        public class AccountMetaData
        {
            [ScaffoldColumn(false)]
            public object Id { get; set; }

            [Required(ErrorMessage = "A Name is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Name { get; set; }

            [Required(ErrorMessage = "An Address is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Address { get; set; }

            [Required(ErrorMessage = "A Description is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Description { get; set; }

            [DisplayName("Industrial Sector")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object IndustrialSector { get; set; }

        }

    }

    public enum AccountType
    {
        Current = 1,
        Saving,
    }
}
