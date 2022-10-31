using Microsoft.AspNetCore.Mvc;
using WIlson.JogoDaVelha.Domain.Contracts.Game;
using WIlson.JogoDaVelha.Domain.Contracts.Player;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDaVelha.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _playerService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PlayerRequest playerRequest)
    {
        try
        {
            var result = await _playerService.Post(playerRequest);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }
}