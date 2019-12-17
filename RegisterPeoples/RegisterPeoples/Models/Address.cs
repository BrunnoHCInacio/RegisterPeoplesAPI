using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Models
{
    public class Address : Entity
    { 
        public Guid PeopleId { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado")]
        [StringLength(150, ErrorMessage = "O logradouro deve conter 7 caracteres", MinimumLength = 2)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O logradouro deve ser informado")]
        [StringLength(150, ErrorMessage = "O logradouro deve conter entre 2 e 150 caracteres", MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "O bairo deve ser informado")]
        [StringLength(150, ErrorMessage = "O bairro deve conter entre 2 e 150 caracteres", MinimumLength = 2)]
        public string District { get; set; }
        [Required(ErrorMessage = "A cidade deve ser informada")]
        [StringLength(150, ErrorMessage = "A cidade deve conter entre 2 e 150 caracteres", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = " O estado deve ser informado")]
        public State State { get; set; }

        [Required(ErrorMessage = "O país deve ser informado")]
        public string Country { get; set; }


        public People People { get; set; }
    }
}
