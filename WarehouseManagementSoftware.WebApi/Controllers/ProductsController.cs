using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSoftware.BLL.DataTransferObject;
using WarehouseManagementSoftware.BLL.Interfaces;
using WarehouseManagementSoftware.BLL.Services;
using WarehouseManagementSoftware.DAL.Repositories;
using WarehouseManagementSoftware.WebApi.ViewModels;

namespace WarehouseManagementSoftware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService productService = new ProductService(new EFUnitOfWork());

        [HttpGet]
        public ActionResult<IEnumerable<ProductView>> GetAllProducts()
        {
            var mapper = new MapperConfiguration(
                            configuration => configuration.
                            CreateMap<ProductDTO, ProductView>()).
                            CreateMapper();
            return mapper.Map<IEnumerable<ProductDTO>, 
                List<ProductView>>(productService.GetProducts());
        }
        
        [HttpPost]
        public ActionResult<ProductView> Create(ProductView product)
        {
            if (product == null)
                return BadRequest("Invalid Data");
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<ProductView, ProductDTO>()).
                             CreateMapper();
            productService.AddProduct(mapper.Map<ProductView, ProductDTO>(product));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<ViewModels.ProductView> DeleteProduct(int id)
        {

            productService.DeleteProduct(id);
            return Ok();    
        }


        [HttpPut]
        public ActionResult<ViewModels.ProductView> Update(ViewModels.ProductView product)
        {
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<ProductView, ProductDTO>()).
                             CreateMapper();
            productService.Update(mapper.Map<ProductView, ProductDTO>(product));
            return Ok();
        }

    }
}
