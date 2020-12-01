using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dream_voyage.Domain
{
    public class DVUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Логин")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Логин не может быть длинее 30 символов.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Пароль не может быть короче 8 символов.")]
        public string Password { get; set; }
    }
}
