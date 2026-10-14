using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;


namespace Utils.Generics
{
    public interface IRepository<T> where T : class
    {


        Task InsertOneAsync( T entity);

        Task InsertManyAsync( IEnumerable<T> entities );

        Task<T?> FindOneAsync(object key);

        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes);


        Task UpdateOneAsync(T entity );
        Task UpdateManyAsync(IEnumerable<T> entities );


        Task DeleteOneAsync(object key);
        Task DeleteOneAsync(T entity);
        Task DeleteManyAsync(IEnumerable<T> entities );
        Task DeleteManyAsync(Expression<Func<T, bool>>? where = null);

        Task<int> CountAsync(Expression<Func<T, bool>>? where  = null);
        Task<int> AnyAsync(Expression<Func<T, bool >>? where = null);
    }
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? where = null) => await _set.AnyAsync(where ?? (x => true));

        public async Task<int> CountAsync(Expression<Func<T, bool>>? where = null) => await _set.CountAsync(where ?? (x => true));


        public Task DeleteManyAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(Expression<Func<T, bool>>? where = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOneAsync(object key)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOneAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FindOneAsync(object key)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task InsertOneAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateManyAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOneAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<T>.AnyAsync(Expression<Func<T, bool>>? where)
        {
            throw new NotImplementedException();
        }
    }
}
