using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EasyCRM.Model.Attributes;

namespace EasyCRM.Model.Domains
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }

        // Validation rules for the User class
        [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public class UserMetaData
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

            [Required(ErrorMessage = "A User Name is required")]
            [DisplayName("User Name")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object UserName { get; set; }

            [Required(ErrorMessage = "A Password is required")]
            [ValidatePasswordLength(4)]
            [DataType(DataType.Password)]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Password { get; set; }

            [Required(ErrorMessage = "A Confirmation Password is required")]
            [DisplayName("Confirm Password")]
            [DataType(DataType.Password)]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object ConfirmPassword { get; set; }

            [Required(ErrorMessage = "A Email Address is required")]
            [DataType(DataType.EmailAddress, ErrorMessage = "The Email Address is invalid")]
            [DisplayName("Email Address")]
            public object Email { get; set; }



            
        }
    }

}
