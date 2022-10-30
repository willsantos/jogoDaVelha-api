using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

namespace Wilson.JogoDaVelha.Repository;

public class GameRepository : IGameRepository
{
    public Task<IEnumerable<GameEntity>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<GameEntity> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GameEntity> Post(GameEntity request)
    {
        throw new NotImplementedException();
    }

    public Task<GameEntity> Put(GameEntity request, int? id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int request)
    {
        throw new NotImplementedException();
    }
}