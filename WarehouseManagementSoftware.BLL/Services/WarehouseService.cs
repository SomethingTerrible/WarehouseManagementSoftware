using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.BLL.DataTransferObject;
using WarehouseManagementSoftware.BLL.Interfaces;
using WarehouseManagementSoftware.DAL.Entities;
using WarehouseManagementSoftware.DAL.Interfaces;

namespace WarehouseManagementSoftware.BLL.Services
{   
    public class WarehouseService :IWarehouseService
    {
        IUnitOfWork Database { get; set; }

        public WarehouseService(IUnitOfWork database)
        {
            Database = database;
        }

        public void DeleteStock(Guid id)
        {
            var stock = Database.Warehouses.Get(id);
            if (stock == null)
                throw new ArgumentNullException("Такого склада нет ");
            Database.Warehouses.Delete(id);
            Database.Save();
        }

       
        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<WarehouseDTO> GetWarehouses()
        {
            var mapper = new MapperConfiguration(configuration => 
                             configuration
                             .CreateMap<Warehouse, WarehouseDTO>())
                             .CreateMapper();

            return mapper.Map<IEnumerable<Warehouse>, List<WarehouseDTO>>(Database.Warehouses.GetAll());

        }

        public void MakeStock(WarehouseDTO stock)
        {
            if (stock == null)
                throw new ArgumentException("Неверное значение stock");
            Warehouse warehouse = new Warehouse
            {
                Id = stock.Id,
                WarehouseName = stock.WarehouseName,
                WarehouseAddress = stock.WarehouseAddress
            };
            Database.Warehouses.Create(warehouse);
            Database.Save();
        }

        public void Update(WarehouseDTO stock)
        {
            var mapper = new MapperConfiguration(
                             configration => configration.
                             CreateMap<WarehouseDTO, Warehouse>()).
                             CreateMapper();
            Database.Warehouses.Update(mapper.Map<WarehouseDTO, Warehouse>(stock));
            Database.Save();
        }
    }
}
