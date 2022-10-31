using Microsoft.AspNetCore.Mvc;
using WIlson.JogoDaVelha.Domain.Contracts.Game;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDaVelha.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _gameService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Get([FromBody] GameRequest gameRequest)
    {
        return Ok(await _gameService.Post(gameRequest));
    }
}