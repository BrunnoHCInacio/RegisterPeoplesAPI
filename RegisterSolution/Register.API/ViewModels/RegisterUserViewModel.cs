using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage ="O email é obrigatório")]
        [EmailAddress(ErrorMessage ="O email está em formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, ErrorMessage ="A senha deve conter pelo menos 8 caracteres", MinimumLength =8)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage =" As senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email está em formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, ErrorMessage = "A senha deve conter pelo menos 8 caracteres", MinimumLength = 8)]
        public string Password { get; set; }

    }

    public class UserTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class ClaimViewModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }
}
