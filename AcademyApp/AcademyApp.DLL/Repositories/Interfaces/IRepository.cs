using AcademyApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.DLL.Repositories.Interfaces
{
    public interface IRepository<T>where T : BaseEntity
    {
        T Get(int id);
        T Get(int id, bool isTracking = false, params string[] includes);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(bool isTracking = false, int page = 1, int take = 2,params string[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void SaveChanges();
        bool IsExist(Expression<Func<T, bool>> predicate);
    }
}
