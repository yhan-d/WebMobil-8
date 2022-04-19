using System.ComponentModel.DataAnnotations;

namespace AdminTemplate.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="Require Password Field")]
        [StringLength(100,MinimumLength = 6, ErrorMessage = "Password length must be six character! ")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Require Repeat Password Field")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords aren't equals!")]
        public string ConfirmNewPassword { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }

    }
}
