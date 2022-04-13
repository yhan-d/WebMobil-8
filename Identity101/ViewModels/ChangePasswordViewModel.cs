using System.ComponentModel.DataAnnotations;

namespace Identity101.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "E-posta alanı gereklidir. ")]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}
