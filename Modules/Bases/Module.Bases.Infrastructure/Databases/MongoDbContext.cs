using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Module.Bases.Infrastructure.Databases
{
    public class BaseDbOption
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public class MongoDbContext<O> where O : BaseDbOption, new()
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly string _databaseNamePrefix;

        public MongoDbContext(IOptions<O> options, string databaseNamePrefix = "")
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _databaseNamePrefix = databaseNamePrefix;
        }

        public IMongoCollection<T> Get<T>() 
        { 
            return _mongoDatabase.GetCollection<T>(_databaseNamePrefix + nameof(T)); 
        }
    }
}
