using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.API.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.ViewModels
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "product")]
    public class ProductImageViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }

        [Required(ErrorMessage = "O nome do produto deve ser informado")]
        [StringLength(200, ErrorMessage = " O nome do produto deve conter entre {2} e {1} caracteres", 
                      MinimumLength =2)]
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUpload { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "O valor deve ser informado")]
        public string Value { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DateRegister { get; set; }
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public string ProviderName { get; set; }

    }
}
