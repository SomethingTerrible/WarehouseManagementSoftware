using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.BLL.DataTransferObject;

namespace WarehouseManagementSoftware.BLL.Interfaces
{
    public interface IProductInWarehouseService
    {
        void DeleteItem(int id);

        void AddProductInStock(ProductsInWarehousesDTO item);

        IEnumerable<ProductsInWarehousesDTO> GetAll();

        void Update(ProductsInWarehousesDTO productInStock);
        void Dispose();
    }
}
