﻿using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.DAL.Entities;

namespace WarehouseManagementSoftware.DAL.Entities
{
    public class ProductInWarehouse
    { 
        public int Id { get; set; }
        public Product Product{ get; set; }
        
        public Warehouse Warehouse { get; set; }

    }
}