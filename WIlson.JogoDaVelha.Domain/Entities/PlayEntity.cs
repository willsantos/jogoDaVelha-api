using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WIlson.JogoDaVelha.Domain.Enums;

namespace WIlson.JogoDaVelha.Domain.Entities;

public class PlayEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("game")]
    public int GameId { get; set; }

    [ForeignKey("game")]
    public int PlayerId { get; set; }

    public PlaySymbolEnum Symbol { get; set; }

    public string Position { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public GameEntity Game { get; set; }
    public PlayerEntity Player { get; set; }
    
    
    
}