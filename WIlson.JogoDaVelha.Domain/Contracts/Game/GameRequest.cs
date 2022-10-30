using WIlson.JogoDaVelha.Domain.Enums;

namespace WIlson.JogoDaVelha.Domain.Contracts.Game;

public class GameRequest
{
    public DateTime Date { get; set; }

    public int PlayerA { get; set; }

    public int PlayerB { get; set; }

    public GameStatusEnum Status { get; set; } 
}