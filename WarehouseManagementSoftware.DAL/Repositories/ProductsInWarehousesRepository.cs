using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseManagementSoftware.DAL.Context;
using WarehouseManagementSoftware.DAL.Entities;
using WarehouseManagementSoftware.DAL.Interfaces;

namespace WarehouseManagementSoftware.DAL.Repositories
{
    class ProductsInWarehousesRepository : IRepository<ProductsInWarehouses>
    {
        private ApplicationContext _db;

        public ProductsInWarehousesRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(ProductsInWarehouses item)
        {
            _db.ProductsInWarehouses.Add(item);
        }

        public void Delete(int id)
        {
            var productInStock = _db.ProductsInWarehouses.Find(id);
            if (productInStock != null)
                _db.ProductsInWarehouses.Remove(productInStock);
        }

        public IEnumerable<ProductsInWarehouses> Find(Func<ProductsInWarehouses, bool> predicate)
        {
            return _db.ProductsInWarehouses.Where(predicate).ToList();
        }

        public ProductsInWarehouses Get(int id)
        {
            return _db.ProductsInWarehouses.Find(id);
        }

        public IEnumerable<ProductsInWarehouses> GetAll()
        {
            return _db.ProductsInWarehouses;
        }

        public void Update(ProductsInWarehouses item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
