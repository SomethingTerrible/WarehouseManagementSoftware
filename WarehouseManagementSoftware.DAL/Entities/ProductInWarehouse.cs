using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.DAL.Entities;

namespace WarehouseManagementSoftware.DAL.Entities
{
    public class ProductInWarehouse
    { 
        public Guid Id { get; set; }

        public Guid ProductId{ get; set; }
        
        public Guid  WarehouseId { get; set; }

    }
}
