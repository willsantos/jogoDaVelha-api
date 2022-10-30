using WIlson.JogoDaVelha.Domain.Contracts.Game;
using WIlson.JogoDaVelha.Domain.Entities;

namespace WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

public interface IGameRepository : IBaseCrud<GameEntity,GameEntity>
{
    
}