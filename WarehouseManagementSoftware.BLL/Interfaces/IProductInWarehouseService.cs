using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.BLL.DataTransferObject;

namespace WarehouseManagementSoftware.BLL.Interfaces
{
    public interface IProductInWarehouseService
    {
        void DeleteItem(int id);

        void AddProductInStock(ProductDTO product, WarehouseDTO warehouse, int id);

        IEnumerable<ProductsInWarehousesDTO> GetAll();

        void Dispose();
    }
}
