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
    public class ProductsInWarehousesController : ControllerBase
    {
        public readonly IProductInWarehouseService productInWarehouse =
            new ProductInWarehouseService(new EFUnitOfWork());

        [HttpGet]
        public ActionResult<IEnumerable<ProductInWarehouseView>> GetAll()
        {

            
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<ProductsInWarehousesDTO, ProductInWarehouseView>()).
                             CreateMapper();
            return mapper.Map<IEnumerable<ProductsInWarehousesDTO>,
                List<ProductInWarehouseView>>(productInWarehouse.GetAll());
        }

        [HttpPost]
        public ActionResult<ProductInWarehouseView> Create(ProductInWarehouseView value)
        {
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<ProductInWarehouseView, ProductsInWarehousesDTO>()).
                             CreateMapper();
            productInWarehouse.AddProductInStock(mapper.Map<ProductInWarehouseView, ProductsInWarehousesDTO>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductInWarehouseView> Delete(Guid id)
        {
            productInWarehouse.DeleteItem(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult<ProductInWarehouseView> Update(ProductInWarehouseView productInStock)
        {
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<ProductInWarehouseView, ProductsInWarehousesDTO>()).
                             CreateMapper();
            productInWarehouse.Update(mapper.Map<ProductInWarehouseView, ProductsInWarehousesDTO>(productInStock));
            return Ok();
        }

    }
}
