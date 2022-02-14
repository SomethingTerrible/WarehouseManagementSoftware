using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseManagementSoftware.DAL.Context;
using WarehouseManagementSoftware.DAL.Entities;
using WarehouseManagementSoftware.DAL.Interfaces;

namespace WarehouseManagementSoftware.DAL.Repositories
{
    class ProductsInWarehousesRepository : IRepository<ProductInWarehouse>
    {
        private ApplicationContext _db;

        public ProductsInWarehousesRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(ProductInWarehouse item)
        {
            _db.ProductsInWarehouses.Add(item);
        }

        public void Delete(Guid id)
        {
            var productInStock = _db.ProductsInWarehouses.Find(id);
            if (productInStock != null)
                _db.ProductsInWarehouses.Remove(productInStock);
        }

        public IEnumerable<ProductInWarehouse> Find(Func<ProductInWarehouse, bool> predicate)
        {
            return _db.ProductsInWarehouses.Where(predicate).ToList();
        }

        public ProductInWarehouse Get(Guid id)
        {
            return _db.ProductsInWarehouses.Find(id);
        }

        public IEnumerable<ProductInWarehouse> GetAll()
        {
            return _db.ProductsInWarehouses;
        }

        public void Update(ProductInWarehouse item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
