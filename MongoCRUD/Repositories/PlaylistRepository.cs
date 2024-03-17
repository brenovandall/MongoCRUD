using MongoCRUD.Data;
using MongoCRUD.Models;
using MongoCRUD.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoCRUD.Repositories;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly MongoDBService _mongoDBService;
    public PlaylistRepository(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }
    public Playlist CreatePlaylist(Playlist playlist)
    {
        var collection = _mongoDBService.GetCollection();

        collection.InsertOne(playlist);

        return playlist;
    }

    public void DeletePlaylist(string id)
    {
        var collection = _mongoDBService.GetCollection();

        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        collection.DeleteOne(filter);
    }

    public IReadOnlyList<Playlist> GetAllPlaylists()
    {
        var collection = _mongoDBService.GetCollection();

        return collection.Find(new BsonDocument()).ToList();
    }

    public IFindFluent<Playlist, Playlist> AddToPlaylist(string id, string movies)
    {
        var collection = _mongoDBService.GetCollection();

        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("movieIds", movies);
        collection.UpdateOne(filter, update);

        var playlist = collection.Find(filter);

        return playlist;
    }

}
