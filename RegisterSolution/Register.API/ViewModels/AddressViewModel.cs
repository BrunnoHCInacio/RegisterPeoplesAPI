using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O logradouro deve ser informado")]
        [StringLength(200, ErrorMessage = " O logradouro deve conter entre {2} e {1} caracteres",
                      MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "O  número deve ser informado")]
        [StringLength(50, ErrorMessage = "O número deve conter entre {2} e {1} caracteres", 
                      MinimumLength = 1)]
        public string Number { get; set; }
        public string Complement { get; set; }

        [Required(ErrorMessage = "O bairro deve ser informado")]
        [StringLength(100, ErrorMessage = "O bairro deve conter entre {2} e {1} caracteres", 
                      MinimumLength = 2)]
        public string District { get; set; }

        [Required(ErrorMessage = "A cidade deve ser informada")]
        [StringLength(100, ErrorMessage = "A cidade deve conter entre {2} e {1} caracteres", 
                      MinimumLength = 2)]
        public string City { get; set; }
        [Required(ErrorMessage = "O estado deve ser informado")]
        [StringLength(50, ErrorMessage = "O estado deve conter entre {2} e {1} caracteres", 
                      MinimumLength = 2)]
        public string State { get; set; }

        [Required(ErrorMessage = "O país deve ser informado")]
        [StringLength(50, ErrorMessage = "O país deve conter entre {2} e {1} caracteres",
                      MinimumLength = 2)]
        public string Contry { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado")]
        [StringLength(8, ErrorMessage = "O CEP deve conter entre {2} e {1} caracteres",
                      MinimumLength = 8)]
        public string ZipCode { get; set; }

        public Guid ProviderId { get; set; }
    }
}
