using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Enums;

namespace WIlson.JogoDaVelha.Domain.Contracts.Game;

public class GameResponse
{
    public int Id { get; set; }

    public DateTime Date { get; set; } 

    public int PlayerA { get; set; }

    public int PlayerB { get; set; }

    public GameStatusEnum Status { get; set; }
    
    public IList<PlayerEntity> Players { get; set; }

    
}