using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

namespace Wilson.JogoDaVelha.Repository;

public class PlayRepository: IPlayRepository
{
    public Task<IEnumerable<PlayEntity>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<PlayEntity> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PlayEntity> Post(PlayEntity request)
    {
        throw new NotImplementedException();
    }

    public Task<PlayEntity> Put(PlayEntity request, int? id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int request)
    {
        throw new NotImplementedException();
    }
}