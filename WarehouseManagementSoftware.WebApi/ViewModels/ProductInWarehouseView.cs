using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementSoftware.WebApi.ViewModels
{
    public class ProductInWarehouseView
    {
        public int Id { get; set; }

        public int  ProductId { get; set; }

        public int WarehouseId { get; set; }
    }
}
