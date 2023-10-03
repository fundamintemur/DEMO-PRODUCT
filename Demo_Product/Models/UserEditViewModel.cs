﻿using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    //bu model kullanıcı bilgileri düzenlenecek bir  model olacak.
    public class UserEditViewModel
    {

        [Required(ErrorMessage = "Lütfen isim giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisim giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen cinsiyet giriniz")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "Lütfen şifreleri eşleştiğinden emin olun")]
        public string ConfirmPassword { get; set; }
    }
}
