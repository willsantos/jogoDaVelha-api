using WIlson.JogoDaVelha.Domain.Enums;

namespace WIlson.JogoDaVelha.Domain.Entities;

public class GameEntity
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public int PlayerA { get; set; }

    public int PlayerB { get; set; }

    public GameStatusEnum Status { get; set; } = GameStatusEnum.Preparing;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? EditedAt { get; set; } = null;

    public DateTime? DeletedAt { get; set; } = null;

}