using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSoftware.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        IEnumerable<T> Find(Func<T, bool> predicate);

        void Create(T item);

        void Update(T item);

        void Delete(Guid id);
    }
}
