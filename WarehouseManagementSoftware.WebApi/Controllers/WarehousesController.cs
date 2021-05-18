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
    public class WarehousesController : ControllerBase
    {

        public readonly IWarehouseService warehouseService = new WarehouseService(new EFUnitOfWork());

        [HttpGet]
        public ActionResult<IEnumerable<WarehouseView>> GetWarehouses()
        {
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<WarehouseDTO, WarehouseView>()).
                             CreateMapper();
            return mapper.Map<IEnumerable<WarehouseDTO>, 
                   List<WarehouseView>>(warehouseService.GetWarehouses());
        }

        [HttpPost]
        public ActionResult<WarehouseView> Create(WarehouseView stock)
        {
            if (stock == null)
                return BadRequest("Invalid Datat");
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<WarehouseView, WarehouseDTO>()).
                             CreateMapper();
            warehouseService.MakeStock(mapper.Map<WarehouseView, WarehouseDTO>(stock));
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<WarehouseView> Delete(int id)
        {
            warehouseService.DeleteStock(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult<WarehouseView> Update(WarehouseView stock)
        {
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<WarehouseView, WarehouseDTO>()).
                             CreateMapper();
            warehouseService.Update(mapper.Map<WarehouseView, WarehouseDTO>(stock));
            return Ok();
        }
    }
}
