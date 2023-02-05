using InvoiceApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using InvoiceApp.Models;

namespace InvoiceApp.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private DbSet<T> _entities;
        private InvoiceDataContext _context { get; set; }
        public GenericRepository(InvoiceDataContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(decimal id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<int> Insert(T entity)
        {
            _entities.Add(entity);
            return await Save();
        }

        public async Task<bool> Modify(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                int i = await Save();
                if (i > 0) 
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
            
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}