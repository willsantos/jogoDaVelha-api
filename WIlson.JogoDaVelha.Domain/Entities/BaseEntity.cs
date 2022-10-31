using System.ComponentModel.DataAnnotations;

namespace WIlson.JogoDaVelha.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}