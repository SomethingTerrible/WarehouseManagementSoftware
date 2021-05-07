using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.DAL.Entities;

namespace WarehouseManagementSoftware.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// При именовании перменной с большой буквы, возникает ошибка 
        /// Npgsql.PostgersException 42p01 - Не найдена сущность Product
        /// При измении имени в БД, не работает команда Select, не ищет сущности
        /// </summary>

        public DbSet<Product> Products { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<ProductInWarehouse> ProductsInWarehouses { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
    }
}
