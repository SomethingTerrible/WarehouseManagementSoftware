using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WarehouseManagementSoftware.DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        public string  ProductName { get; set; }
    }
}
