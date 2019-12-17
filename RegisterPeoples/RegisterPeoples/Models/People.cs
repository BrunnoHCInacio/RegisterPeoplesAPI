using System;
using System.ComponentModel.DataAnnotations;

namespace RegisterPeoples.Models
{
    public class People : Entity
    {
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(150, ErrorMessage = " O nome deve conter entre 2 e 150 caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF deve ser informado")]
        [StringLength(11, ErrorMessage = " O nome CPF conter somente 11 caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O RG deve ser informado")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "A data de nascimento deve ser informado")]
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
    }
}
