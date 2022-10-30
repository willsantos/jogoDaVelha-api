using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

namespace Wilson.JogoDaVelha.Repository;

public class PlayerRepository : IPlayerRepository
{
    public Task<IEnumerable<PlayerEntity>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<PlayerEntity> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerEntity> Post(PlayerEntity request)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerEntity> Put(PlayerEntity request, int? id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int request)
    {
        throw new NotImplementedException();
    }
}