using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementSoftware.WebApi.ViewModels
{
    public class WarehouseView
    {
        public Guid Id { get; set; } 

        public string WarehouseName { get; set; }
        
        public string WarehouseAddress { get; set; }
    }
}
