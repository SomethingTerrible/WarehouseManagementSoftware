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
    public class ProdcutInWarehouseService : IProductInWarehouseService
    {
        IUnitOfWork Database { get; set; }

        public void AddProductInStock(ProductDTO product, WarehouseDTO warehouse, int id)
        {
            var productExists = (Database.Products.Get(product.Id) != null) ;
            var warehouseExists = (Database.Warehouses.Get(warehouse.Id) != null);
            if (!(productExists && warehouseExists))
                throw new ArgumentNullException("Нет элементов с такими id");
            Database.ProductsInWarehouses.Create(new ProductInWarehouse
            {
                Id = id,
                Product = new Product { Id = product.Id, ProductName = product.ProductName },
                Warehouse = new Warehouse
                {
                    Id = warehouse.Id,
                    WarehouseName = warehouse.WarehouseName,
                    WarehouseAddress = warehouse.WarehouseAddress
                }
            });
            Database.Save();
        }

        public void DeleteItem(int id)
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
    }
}
