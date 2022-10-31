using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Game;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDavelha.Services;

public class GameService : IGameService
{
    public readonly IGameRepository _gameRepository;
    public readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GameResponse>> Get()
    {
        var listAllGames = await _gameRepository.Get();
        return _mapper.Map<IEnumerable<GameResponse>>(listAllGames);
    }

    public Task<GameResponse> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<GameResponse> Post(GameRequest request)
    {
        var gameRequest = _mapper.Map<GameEntity>(request);
        var gamePosted = await _gameRepository.Post(gameRequest);
        return _mapper.Map<GameResponse>(gamePosted);
    }

    public Task<GameResponse> Put(GameRequest request, int? id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int request)
    {
        throw new NotImplementedException();
    }
}