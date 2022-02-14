using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementSoftware.WebApi.ViewModels
{
    public class ProductInWarehouseView
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid WarehouseId { get; set; }
    }
}
