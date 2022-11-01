using Microsoft.EntityFrameworkCore;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

namespace Wilson.JogoDaVelha.Repository;

public class PlayRepository: IPlayRepository
{
    private readonly ApiDbContext _context;

    public PlayRepository(ApiDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<PlayEntity>> Get(int id)
    {
        return await _context.Plays.Where(prop => prop.GameId == id).AsNoTracking().ToListAsync();
    }

    public Task<IEnumerable<PlayEntity>> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<PlayEntity> GetById(int id)
    {
        return await _context.Plays.Where(prop=>prop.Id ==id).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<PlayEntity> GetLastPlay(int gameId)
    {
        return await _context.Plays.Where(prop => prop.GameId == gameId).OrderBy(prop=>prop.CreatedAt).AsNoTracking().LastOrDefaultAsync();
    }

    public async Task<IEnumerable<PlayEntity>> GetPlaysByPlayer(int gameId, int playerId)
    {
        return await _context.Plays.Where(prop => prop.GameId == gameId && prop.PlayerId == playerId)
            .AsNoTracking().ToListAsync();
    }

    public async Task<PlayEntity> Post(PlayEntity request)
    {
        request.CreatedAt = DateTime.Now;
        await _context.Plays.AddAsync(request);
        await _context.SaveChangesAsync();
        return request;
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