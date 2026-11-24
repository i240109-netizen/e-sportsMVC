using System.ComponentModel.DataAnnotations;

namespace e_sportsMVC.Models
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Nome completo")]
        public string FullName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required, Compare(nameof(Password)), DataType(DataType.Password), Display(Name = "Confirmar palavra-passe")]
        public string ConfirmPassword { get; set; } = "";
    }

    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }
    }
}