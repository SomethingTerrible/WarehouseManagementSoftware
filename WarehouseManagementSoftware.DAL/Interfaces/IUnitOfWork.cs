using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.DAL.Entities;

namespace WarehouseManagementSoftware.DAL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<Product> Products { get; }
        
        IRepository<ProductsInWarehouses> ProductsInWarehouses { get; }
        IRepository<Warehouse> Warehouses { get; }

        void Save();

    }
}
