using Module.Bases.Domain.Models;
using Module.Bases.Domain.Stores;
using Module.Bases.Infrastructure.Databases;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Module.Bases.Application.Stores
{
    public class BaseStore<T, D, O> : IBaseStore<T> 
        where T : BaseEntity, new() 
        where D : MongoDbContext<O> where O : BaseDbOption, new()
    {
        private readonly IMongoCollection<T> _collection;

        public BaseStore(D dbContext) 
        {
            _collection = dbContext.Get<T>();
        }

        public Task AddAsync(T entity)
        {
            return _collection.InsertOneAsync(entity);
        }

        public Task Delete(string id)
        {
            return _collection.DeleteOneAsync(Builders<T>.Filter.Where(x => x.Id == id));
        }

        public Task<List<T>> Find(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Update(string id, T entity)
        {
            return _collection.ReplaceOneAsync(Builders<T>.Filter.Where(x => x.Id == id), entity);
        }
    }
}
