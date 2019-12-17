using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace RegisterPeoples.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "O e-mail deve ser informado")]
        [EmailAddress(ErrorMessage = "E-mail no formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        [StringLength(50, ErrorMessage = "A senha deve conter pelo menos 8 caracteres", MinimumLength = 8)]
        public string Password { get; set; }
    }

    public class RegisterUser
    {
        [Required(ErrorMessage = "O e-mail deve ser informado")]
        [EmailAddress(ErrorMessage = "E-mail no formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        [StringLength(50, ErrorMessage = "A senha deve conter pelo menos 8 caracteres", MinimumLength = 8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
