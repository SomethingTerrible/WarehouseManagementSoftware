using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSoftware.BLL.DataTransferObject
{
    public class WarehouseDTO
    {
        public Guid Id { get; set; }

        public string  WarehouseName { get; set; }

        public string WarehouseAddress { get; set; }


    }
}
