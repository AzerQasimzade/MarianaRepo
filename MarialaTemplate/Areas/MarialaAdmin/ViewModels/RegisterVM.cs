using System.ComponentModel.DataAnnotations;

namespace MarialaTemplate.Areas.MarialaAdmin.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
