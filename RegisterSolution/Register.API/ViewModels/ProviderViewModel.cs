using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.ViewModels
{
    public class ProviderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor deve ser informado")]
        [StringLength(100, ErrorMessage = "O nome do fornecedor deve conter entre {2} e {1} caracteres", 
                      MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ deve ser informado")]
        [StringLength(14, ErrorMessage = "O documento deve conter entre {2} e {1} caracteres", 
                      MinimumLength = 11)]
        public string Document { get; set; }
        public int TypeProvider { get; set; }
        public AddressViewModel Address { get; set; }
        public bool Active { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
