using System;
using Ninject.Modules;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSoftware.DAL.Interfaces;
using WarehouseManagementSoftware.DAL.Repositories;

namespace WarehouseManagementSoftware.BLL.DI
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
