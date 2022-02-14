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
            {
                throw new ArgumentException("Неверные данные о продукте");
            }
            Product n_prod = new Product
            {
                Id = product.Id,
                ProductName = product.ProductName
            };
            Database.Products.Create(n_prod);
            Database.Save();
        }

        public void DeleteProduct(Guid id)
        {
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

        public void Update(ProductDTO product)
        {
            var mapper = new MapperConfiguration(
                             configuration => configuration.
                             CreateMap<ProductDTO,Product>()).
                             CreateMapper();
            Database.Products.Update(mapper.Map<ProductDTO, Product>(product));
            Database.Save();
        }
    }
}
