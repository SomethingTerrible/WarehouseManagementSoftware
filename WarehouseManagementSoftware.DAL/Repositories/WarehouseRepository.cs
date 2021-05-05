using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseManagementSoftware.DAL.Context;
using WarehouseManagementSoftware.DAL.Entities;
using WarehouseManagementSoftware.DAL.Interfaces;

namespace WarehouseManagementSoftware.DAL.Repositories
{
    public class WarehouseRepository : IRepository<Warehouse>
    {
        private ApplicationContext _db;

        public WarehouseRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(Warehouse item)
        {
            _db.Warehouses.Add(item);
        }

        public void Delete(int id)
        {
            var warehouse = _db.Warehouses.Find(id);
            if (warehouse != null)
                _db.Warehouses.Remove(warehouse);
        }

        public IEnumerable<Warehouse> Find(Func<Warehouse, bool> predicate)
        {
            return _db.Warehouses.Where(predicate).ToList();
        }

        public Warehouse Get(int id)
        {
            return _db.Warehouses.Find(id);
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _db.Warehouses;
        }

        public void Update(Warehouse item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
