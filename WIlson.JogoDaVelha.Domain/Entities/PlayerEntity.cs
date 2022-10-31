namespace WIlson.JogoDaVelha.Domain.Entities;

public class PlayerEntity : BaseEntity
{
    public string Name { get; set; }

    public string Password { get; set; }

    public DateTime? DeletedAt { get; set; } = null;


    public IList<GameEntity> Games { get; set; }
}