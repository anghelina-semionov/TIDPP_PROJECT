using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dream_voyage.Web.Models
{
    public class UserRegister
    {
        [Required]
        [Display(Name = "Логин")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Логин не может быть короче 5 и длиннее 30 символов.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Пароль не может быть короче 8 символов.")]
        public string Password { get; set; }
    }
}