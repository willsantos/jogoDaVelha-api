using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WIlson.JogoDaVelha.Domain.Enums;

namespace WIlson.JogoDaVelha.Domain.Entities;

public class PlayEntity : BaseEntity
{
   
    [ForeignKey("game")]
    public int GameId { get; set; }

    [ForeignKey("player")]
    public int PlayerId { get; set; }

    public PlaySymbolEnum Symbol { get; set; }

    public string Position { get; set; }


    
    public GameEntity Game { get; set; }
    public PlayerEntity Player { get; set; }
    
    
    
}