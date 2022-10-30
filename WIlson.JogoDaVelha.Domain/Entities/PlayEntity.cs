using WIlson.JogoDaVelha.Domain.Enums;

namespace WIlson.JogoDaVelha.Domain.Entities;

public class PlayEntity
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int PlayerId { get; set; }

    public PlaySymbolEnum Symbol { get; set; }

    public string Position { get; set; }

    public DateTime CreatedAt { get; set; }
}