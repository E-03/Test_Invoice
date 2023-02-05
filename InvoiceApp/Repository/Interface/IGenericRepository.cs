using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(decimal id);
        Task<int> Insert(T entity);
        Task<bool> Modify(T entity);
        void Delete(T entity);
        Task<int> Save();
    }
}
