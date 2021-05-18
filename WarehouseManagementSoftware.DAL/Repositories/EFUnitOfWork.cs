using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using WarehouseManagementSoftware.DAL.Context;
using WarehouseManagementSoftware.DAL.Entities;
using WarehouseManagementSoftware.DAL.Interfaces;

namespace WarehouseManagementSoftware.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;

        private IRepository<Product> _products;

        private IRepository<Warehouse> _warehouses;

        private IRepository<ProductInWarehouse> _productsInWarehouses;

        public EFUnitOfWork()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(@"C:\Users\Admin\source\repos\WarehouseManagementSoftware\WarehouseManagementSoftware.DAL\Confi.json");
            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionBuilder
                .UseNpgsql(connectionString)
                .Options;
            _db = new ApplicationContext(options);

        }

        public IRepository<Product> Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_db);
                return _products;

            }
        }

        public IRepository<Warehouse> Warehouses
        {
            get
            {
                if (_warehouses == null)
                    _warehouses = new WarehouseRepository(_db);
                return _warehouses;
            }
        }

        public IRepository<ProductInWarehouse> ProductsInWarehouses
        {
            get
            {
                if (_productsInWarehouses == null)
                    _productsInWarehouses = new ProductsInWarehousesRepository(_db);
                return _productsInWarehouses;
            }
        }


        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
