using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.BLL.DataTransferObject;

namespace WarehouseManagementSoftware.BLL.Interfaces
{
    public interface IWarehouseService
    {
        void DeleteStock(int id);

        void MakeStock(WarehouseDTO stock);

        IEnumerable<WarehouseDTO> GetWarehouses();

        void Update(WarehouseDTO stock);

        void Dispose();
    }
}
