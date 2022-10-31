using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WIlson.JogoDaVelha.Domain.Enums;

namespace WIlson.JogoDaVelha.Domain.Entities;

public class GameEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }
    
    [ForeignKey("players"), Column(Order = 0)]
    public int PlayerA { get; set; }

    [ForeignKey("players"), Column(Order = 1)]
    public int PlayerB { get; set; }

    public GameStatusEnum Status { get; set; } = GameStatusEnum.Preparing;

    public DateTime CreatedAt { get; set; }

    public DateTime? EditedAt { get; set; } = null;

    public DateTime? DeletedAt { get; set; } = null;
    
    //public IList<PlayerEntity> Players { get; set; }

}