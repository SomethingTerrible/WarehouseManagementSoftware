using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSoftware.BLL.DataTransferObject
{
    public class ProductsInWarehousesDTO
    {
       public ProductDTO Product { get; set; }

       public WarehouseDTO Warehouse { get; set; }
    }
}
