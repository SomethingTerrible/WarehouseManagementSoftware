using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.BLL.DataTransferObject;

namespace WarehouseManagementSoftware.BLL.Interfaces
{
    public interface IProductService
    {
        void DeleteProduct(int id);

        void AddProduct(ProductDTO product);

        IEnumerable<ProductDTO> GetProducts();

        void Update(ProductDTO product);

        void Dispose();

    }
}
