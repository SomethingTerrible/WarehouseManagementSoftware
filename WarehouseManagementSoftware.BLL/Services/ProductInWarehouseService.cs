using AutoMapper;
using System;
using System.Collections.Generic;
using WarehouseManagementSoftware.BLL.DataTransferObject;
using WarehouseManagementSoftware.BLL.Interfaces;
using WarehouseManagementSoftware.DAL.Entities;
using WarehouseManagementSoftware.DAL.Interfaces;

namespace WarehouseManagementSoftware.BLL.Services
{
    public class ProductInWarehouseService : IProductInWarehouseService
    {
        IUnitOfWork Database { get; set; }

        public ProductInWarehouseService(IUnitOfWork database)
        {
            Database = database;
        }

        public void AddProductInStock(ProductsInWarehousesDTO item )
        {

            var n_item = new ProductInWarehouse
            {
                Id = item.Id,
                ProductId = item.ProductId,
                WarehouseId = item.WarehouseId
            };
            Database.ProductsInWarehouses.Create(n_item);
            Database.Save();
        }

        public void DeleteItem(Guid id)
        {
            var exists = Database.ProductsInWarehouses.Get(id) != null;
            if (!exists)
                throw new ArgumentException("Не существует такого элемента");
            Database.ProductsInWarehouses.Delete(id);
            Database.Save();

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ProductsInWarehousesDTO> GetAll()
        {
            
            var mapper = new MapperConfiguration(configuration
                             => configuration
                             .CreateMap<ProductInWarehouse, 
                              ProductsInWarehousesDTO>())
                             .CreateMapper();
            return mapper.Map<IEnumerable<ProductInWarehouse>,
                   List<ProductsInWarehousesDTO>>
                   (Database.ProductsInWarehouses.GetAll());
        }

        public void Update(ProductsInWarehousesDTO productInStock)
        {
            var mapper = new MapperConfiguration(
                              configuration => configuration.
                              CreateMap<ProductsInWarehousesDTO, ProductInWarehouse>()).
                              CreateMapper();
            Database.ProductsInWarehouses.
                Update(mapper.Map<ProductsInWarehousesDTO, ProductInWarehouse>(productInStock));
            Database.Save();
        }
    }
}
