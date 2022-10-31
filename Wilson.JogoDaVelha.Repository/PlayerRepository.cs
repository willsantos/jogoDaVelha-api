using Microsoft.EntityFrameworkCore;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;

namespace Wilson.JogoDaVelha.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly ApiDbContext _context;

    public PlayerRepository(ApiDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<PlayerEntity>> Get()
    {
        return await _context.Players.AsNoTracking().ToListAsync();
    }

    public async  Task<PlayerEntity> GetById(int id)
    {
       return await  _context.Players.Where(prop=> prop.Id==id).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<PlayerEntity> Post(PlayerEntity request)
    {
        await _context.Players.AddAsync(request);
        await _context.SaveChangesAsync();
        return request;
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