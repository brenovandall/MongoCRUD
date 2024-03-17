using Microsoft.Extensions.Options;
using MongoCRUD.Data;
using MongoCRUD.Models;
using MongoDB.Driver;

namespace MongoCRUD.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Playlist> _collection;
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _collection = database.GetCollection<Playlist>(mongoDBSettings.Value.CollectionName);
    }

    public IMongoCollection<Playlist> GetCollection()
    {
        return _collection;
    }
}
