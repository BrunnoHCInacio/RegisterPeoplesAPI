using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.API.Extensions;
using Register.API.Interfaces;
using Register.API.Models;
using Register.API.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Controllers
{
    [Authorize]
    [Route("api/products")]
    public class ProductsController : MainController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(INotifier notifier, 
                                  IProductRepository productRepository, 
                                  IProductService productService, 
                                  IMapper mapper,
                                  IUser appUser) : base(notifier, appUser)
        {
            _productRepository = productRepository;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsProviders());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {
            var product = await _productRepository.GetProductProvider(id);
            if (product == null) return NotFound();
            return _mapper.Map<ProductViewModel>(product);
        }

        [ClaimsAuthorize("Product", "Add")]
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var imageName = Guid.NewGuid() + "_" + productViewModel.Image;
            if(!UploadArchive(productViewModel.ImageUpload, imageName))
            {
                return CustomResponse(productViewModel);
            }
            productViewModel.Image = imageName;
            await _productService.Add(_mapper.Map<Product>(productViewModel));
            return CustomResponse(productViewModel);
        }
        
        [HttpPost("adicionar")]
        public async Task<ActionResult<ProductViewModel>> AddAlt(ProductImageViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var imgPrefix = Guid.NewGuid() + "_";
            if (!await UploadArchiveAlternative(productViewModel.ImageUpload, imgPrefix))
            {
                return CustomResponse(productViewModel);
            }
            productViewModel.Image = imgPrefix + productViewModel.ImageUpload.FileName;
            await _productService.Add(_mapper.Map<Product>(productViewModel));
            return CustomResponse(productViewModel);
        }

        [RequestSizeLimit(40000000)]
        [HttpPost("imagem")]
        public async Task<ActionResult<ProductViewModel>> AddImage(IFormFile file)
        {
           
            return Ok(file);
        }

        [ClaimsAuthorize("Product", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if(id != productViewModel.Id)
            {
                Notify("O id informado não pode ser diferente do id cadastrado");
                return CustomResponse();
            }
            var productUpdate = await _productRepository.GetById(id);
            productViewModel.Image = productUpdate.Image;
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if(productViewModel.ImageUpload != null)
            {
                var imageName = Guid.NewGuid() + "_" + productViewModel.Image;
                if (!UploadArchive(productViewModel.ImageUpload, imageName))
                {
                    return CustomResponse(productViewModel);
                }
                productViewModel.Image = imageName;
            }
            productUpdate.Name = productViewModel.Name;
            productUpdate.Description = productViewModel.Description;
            productUpdate.Value = productViewModel.Value;
            productUpdate.Active = productViewModel.Active;
            await _productService.Update(_mapper.Map<Product>(productUpdate));  
            return CustomResponse(productViewModel);
        }

        [ClaimsAuthorize("Product", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null) return NotFound();
            await _productService.Remove(id);
            return CustomResponse();
        }

        private bool UploadArchive(string archive, string imgName)
        {
            if (archive == null || archive.Length == 0)
            {
                Notify("Forneça uma imagem para este produto!");
                return false;
            }
            var imageDataByteArray = Convert.FromBase64String(archive);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgName);
            if (System.IO.File.Exists(filePath))
            {
                Notify("Já existe um arquivo com este nome!");
                return false;
            }
            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);
            return true;
        }

        private async Task<bool> UploadArchiveAlternative(IFormFile archive, string imgPrefix)
        {
            if (archive == null || archive.Length == 0)
            {
                Notify("Forneça uma imagem para este produto!");
                return false;
            }
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefix + archive.FileName);
            if (System.IO.File.Exists(path))
            {
                Notify("Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await archive.CopyToAsync(stream);
            }
            
            return true;
        }
    }

}
