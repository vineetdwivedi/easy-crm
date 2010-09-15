using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyCRM.WebApp.ViewModels
{
    public class LogOnViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }
}