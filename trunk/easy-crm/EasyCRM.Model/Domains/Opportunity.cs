using System.ComponentModel.DataAnnotations;

namespace EasyCRM.Model.Domains
{
    [MetadataType(typeof(OpportunityMetaData))]
    public partial class Opportunity
    {
        // Validation rules for the Opportunity class
        public class OpportunityMetaData
        {
            [ScaffoldColumn(false)]
            public object Id { get; set; }

            [Required(ErrorMessage = "An Amount is required")]
            public object Amount { get; set; }

            [Required(ErrorMessage = "A Description is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Description { get; set; }

        }

    }

    public enum OpportunityStatus
    {
        Proposition = 1,
        InNegotiation,
        Concluded
    }
}
