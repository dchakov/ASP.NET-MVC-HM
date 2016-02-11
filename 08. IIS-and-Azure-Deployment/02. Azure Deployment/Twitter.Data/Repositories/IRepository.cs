using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
