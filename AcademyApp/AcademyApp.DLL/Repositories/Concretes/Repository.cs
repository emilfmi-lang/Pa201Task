using AcademyApp.Core.Models;
using AcademyApp.DLL.Data;
using AcademyApp.DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.DLL.Repositories.Concretes
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public DbSet<T> Table { get; set; }
        public Repository(AppDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();
            SaveChanges();
        }
        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return Table.Find(id);
        }

        public T Get(int id ,bool isTracking = false, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
                query = query.AsNoTracking();
            foreach (var include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public IQueryable<T> GetAll(bool isTracking = false, int page = 1, int take = 2, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
                query = query.AsNoTracking();
            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((page -1)*take).Take(take);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public bool IsExist(Expression<Func<T, bool>> predicate)
        {
            return Table.Any(predicate);
        }
    }
}
