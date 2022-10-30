namespace WIlson.JogoDaVelha.Domain.Entities;

public class PlayerEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? EditedAt { get; set; } = null;

    public DateTime? DeletedAt { get; set; } = null;
    
}