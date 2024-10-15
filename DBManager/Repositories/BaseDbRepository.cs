using DBManager.DTOs;
using MongoDB.Driver;

namespace DBManager.Repositories;

public class BaseDbRepository<T>: IDbRepository<T> where T: class, IDbEntity
{
    protected IMongoCollection<T> Collection { get; private init; }
    
    public BaseDbRepository(MongoConnection mongoConnection, string collectionName)
    {
        Collection = mongoConnection.Db.GetCollection<T>(collectionName);
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        IAsyncCursor<T> result = await Collection.FindAsync(_ => true);
        return result.ToList();
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(t => t.Id == id);
        return await result.FirstOrDefaultAsync();

    }

    public virtual async Task CreateAsync(T t)
    {
        await Collection.InsertOneAsync(t);
    }

    public async Task<bool> UpdateOneAsync(T t)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(nameof(t.Id), t.Id);
        ReplaceOneResult result = await Collection.ReplaceOneAsync(filter, t);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteOneAsync(T t)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(nameof(t.Id), t.Id);
        DeleteResult result = await Collection.DeleteOneAsync(filter);
        return result.DeletedCount > 0;
    }
}