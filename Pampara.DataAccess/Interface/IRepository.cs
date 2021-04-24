using Pampara.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pampara.DataAccess.Interface
{
   public interface IRepository<T>
    {
        public T Create(T _object);
        public T Update(T _object);
        public IEnumerable<T> GetAll();
        public void Delete(int Id);
        public T GetById(int Id);
        public PagedResult<Employee> GetAllPaged(int page, int pageSize);
    }
}
