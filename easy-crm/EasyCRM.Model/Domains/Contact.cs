using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyCRM.Model.Domains
{
    [MetadataType(typeof(ContactMetaData))]
    public partial class Contact
    {

        // Validation rules for the Contact class
        public class ContactMetaData
        {
            [ScaffoldColumn(false)]
            public object Id { get; set; }

            [Required(ErrorMessage = "A Last Name is required")]
            [DisplayName("Last Name")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object LastName { get; set; }

            [Required(ErrorMessage = "A First Name is required")]
            [DisplayName("First Name")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object FirstName { get; set; }

            [Required(ErrorMessage = "An Address is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Address { get; set; }

            [Required(ErrorMessage = "A Email Address is required")]
            [DataType(DataType.EmailAddress, ErrorMessage = "The Email Address is invalid")]
            [DisplayName("Email Address")]
            public object Email { get; set; }
        }
    }

    public enum ContactStatus
    {
        Active = 1,
        Abandoned,
        Reliable,
        UnReliable
    }
}
