using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.DAL.Entities;

namespace WarehouseManagementSoftware.DAL.Entities
{
    public class ProductsInWarehouses
    {
        public int ProductId { get; set; }
        
        public int WarehouseId { get; set; }
    }
}
