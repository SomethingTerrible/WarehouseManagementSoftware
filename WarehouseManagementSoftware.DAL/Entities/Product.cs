using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WarehouseManagementSoftware.DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string  ProductName { get; set; }
    }
}
