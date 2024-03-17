using MongoCRUD.Models;
using MongoDB.Driver;

namespace MongoCRUD.Repositories;

public interface IPlaylistRepository
{
    public IReadOnlyList<Playlist> GetAllPlaylists();
    public IFindFluent<Playlist, Playlist> AddToPlaylist(string id, string movies);
    public Playlist CreatePlaylist(Playlist playlist);
    public void DeletePlaylist(string id);
}
