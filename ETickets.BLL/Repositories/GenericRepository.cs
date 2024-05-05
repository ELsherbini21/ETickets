using ETickets.BLL.Interfaces;
using ETickets.DAL.Data;
using ETickets.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly AppDbContext dbContext;

        public GenericRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        #region CRUD Operations 
        public async Task<IEnumerable<T>> GetAllAsync() => await dbContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await dbContext.FindAsync<T>(id);

        public async Task<T> GetByNameAsync(string name) => await dbContext.FindAsync<T>(name);

        public async Task AddAsync(T entity) => await dbContext.AddAsync(entity);

        public async Task UpdateAsync(T entity) => dbContext.Update(entity);

        public async Task DeleteAsync(T entity) => dbContext.Remove(entity);

        #endregion





    }
}
