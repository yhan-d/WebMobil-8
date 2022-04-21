﻿using System.ComponentModel.DataAnnotations;

namespace AdminTemplate.ViewModels
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage ="Ad alanı gereklidir. ")]
        [Display(Name ="Ad")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir. ")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage ="E-posta alanı gereklidir. ")]
        [EmailAddress]
        public string Email { get; set; }

        
        public DateTime RegisterDate { get; set; }
    }
}
