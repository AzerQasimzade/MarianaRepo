using System.ComponentModel.DataAnnotations;

namespace MarialaTemplate.Areas.MarialaAdmin.ViewModels
{
    public class LoginVM
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string UsernameOrEmail { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsRemembered { get; set; }
    }
}
