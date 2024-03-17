using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCRUD.Models;
using MongoCRUD.Repositories;

namespace MongoCRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaylistController : ControllerBase
{
    private readonly IPlaylistRepository _repository;
    public PlaylistController(IPlaylistRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Playlist>>> Get()
    {
        return Ok(_repository.GetAllPlaylists());
    }

    [HttpPost]
    public async Task<ActionResult<Playlist>> Post(Playlist playlist)
    {
        return Ok(_repository.CreatePlaylist(playlist));
    }

    [HttpPut]
    public async Task<IActionResult> AddToPlaylist(string id, string movieId)
    {
        return Ok(_repository.AddToPlaylist(id, movieId));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        _repository.DeletePlaylist(id);
        return NoContent();
    }
}
