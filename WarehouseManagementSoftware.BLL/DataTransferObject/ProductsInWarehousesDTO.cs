using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSoftware.BLL.DataTransferObject
{
    public class ProductsInWarehousesDTO
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid WarehouseId { get; set; }

    }
}
