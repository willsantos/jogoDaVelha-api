using Microsoft.EntityFrameworkCore;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

namespace Wilson.JogoDaVelha.Repository;

public class GameRepository : IGameRepository
{
    private readonly ApiDbContext _context;

    public GameRepository(ApiDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<GameEntity>> Get()
    {
        

        return await _context.Games.AsNoTracking().ToListAsync();
    }

    public async Task<GameEntity> GetById(int id)
    {
        return await _context.Games.Where(prop=>prop.Id == id).AsNoTracking().FirstOrDefaultAsync();
    }

    
    public async Task<GameEntity> Post(GameEntity request)
    {
        
        await _context.Games.AddAsync(request);
        await _context.SaveChangesAsync();
        return request;
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