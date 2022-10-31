using WIlson.JogoDaVelha.Domain.Enums;
using WIlson.JogoDaVelha.Domain.Interfaces;

namespace WIlson.JogoDaVelha.Domain.Contracts.Play;

public class PlayRequest
{
    public int GameId { get; set; }

    public int PlayerId { get; set; }

    public PlaySymbolEnum Symbol { get; set; }

    public string Position { get; set; }
}