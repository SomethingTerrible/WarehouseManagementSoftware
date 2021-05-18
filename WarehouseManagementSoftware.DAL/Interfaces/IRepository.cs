using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSoftware.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        
        /// <summary>
        /// Переименовать GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        IEnumerable<T> Find(Func<T, bool> predicate);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
