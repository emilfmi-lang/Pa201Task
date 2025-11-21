using LibraryManagementSystem.DLL.Data;
using LibraryManagementSystem.DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DLL.Repositories.Concretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public DbSet<T> Table { get; set; }
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            Table = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                Table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
