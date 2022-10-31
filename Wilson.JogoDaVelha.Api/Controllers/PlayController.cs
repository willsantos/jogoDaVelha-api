using Microsoft.AspNetCore.Mvc;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDaVelha.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayController : ControllerBase
{
    public readonly IPlayService _playService;

    public PlayController(IPlayService playService)
    {
        _playService = playService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _playService.GetPlayByGameId(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PlayRequest playRequest)
    {
        return Ok(await _playService.Post(playRequest));
    }
}