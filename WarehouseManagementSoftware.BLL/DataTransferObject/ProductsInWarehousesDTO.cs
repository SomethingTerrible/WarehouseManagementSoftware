using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSoftware.BLL.DataTransferObject
{
    public class ProductsInWarehousesDTO
    {
        public int Id { get; set; }

        public int  ProductId { get; set; }

        public int  WarehouseId { get; set; }

    }
}
