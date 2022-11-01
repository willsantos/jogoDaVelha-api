using WIlson.JogoDaVelha.Domain.Entities;

namespace WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

public interface IPlayRepository : IBaseCrud<PlayEntity,PlayEntity>
{
    Task<IEnumerable<PlayEntity>> Get(int id);
    Task<PlayEntity> GetLastPlay(int gameId);
    Task<IEnumerable<PlayEntity>> GetPlaysByPlayer(int gameId, int playerId);
}