using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSoftware.DAL.Entities
{
    public class Warehouse
    {
        public Guid Id { get; set; }

        public string  WarehouseName { get; set; }

        public string WarehouseAddress { get; set; }

    }
}
