using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseManagementSoftware.DAL.Context;
using WarehouseManagementSoftware.DAL.Entities;
using WarehouseManagementSoftware.DAL.Interfaces;

namespace WarehouseManagementSoftware.DAL.Repositories
{
    public class ProductRepository :IRepository<Product>
    {
        private ApplicationContext _db;

        public ProductRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(Product item)
        {
            _db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = _db.Products.Find(id);
            if (product != null)
                _db.Products.Remove(product);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _db.Products.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }

        public void Update(Product item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
