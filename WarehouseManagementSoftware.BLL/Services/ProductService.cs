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
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork database)
        {
            Database = database;
        }

        public void AddProduct(ProductDTO product)
        {
            if (product == null)
                throw new ArgumentException("Неверные данные о продукте");
            Product prod = new Product { Id = product.Id, ProductName = product.ProductName };

            Database.Products.Create(prod);
            Database.Save();
        }

        public void DeleteProduct(int id)
        {
            if (id == 0)
                throw new ArgumentException("Неверное значение id");
            var product = Database.Products.Get(id);
            if (product == null)
                throw new ArgumentNullException("Продукт не найден");
            Database.Products.Delete(id);
            Database.Save();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(
                             configuration => configuration
                             .CreateMap<Product, ProductDTO>())
                             .CreateMapper();

            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
