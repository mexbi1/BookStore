using System.ComponentModel.DataAnnotations;

namespace BookStore.BusinessLogicLayer.Views.AccountViews
{
    public class LoginAccountView
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
