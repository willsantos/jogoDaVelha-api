using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDavelha.Services;

public class PlayService : IPlayService
{
    private readonly IPlayRepository _playRepository;
    private readonly IGameService _gameService;
    private readonly IMapper _mapper;


    public PlayService(IPlayRepository playRepository,IGameService gameService, IMapper mapper)
    {
        _playRepository = playRepository;
        _gameService = gameService;
        _mapper = mapper;
    }
    
    
    public Task<IEnumerable<PlayResponse>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<PlayResponse> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PlayResponse>> GetPlayByGameId(int id)
    {
        var listAllPlays = await _playRepository.Get(id);
        return _mapper.Map<IEnumerable<PlayResponse>>(listAllPlays);
    }

    public async Task<PlayResponse> Post(PlayRequest request)
    {
        if(!await CheckGameExists(request.GameId))
            throw new ArgumentException("Partida não existe");

        await CheckPlayerInGame(request.PlayerId,request.GameId);
        
        
        var playEntity = _mapper.Map<PlayEntity>(request);
        var playCreated = await _playRepository.Post(playEntity);
        
        return _mapper.Map<PlayResponse>(playCreated);
    }

    private async Task<bool> CheckPlayerInGame(int playerId, int gameId)
    {
        var game = await _gameService.GetById(gameId);
        return game.PlayerA == playerId || game.PlayerB == playerId;
    }

    private async Task<bool> CheckGameExists(int gameId)
    {
        try
        {
            await _gameService.GetById(gameId);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Task<PlayResponse> Put(PlayRequest request, int? id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int request)
    {
        throw new NotImplementedException();
    }
}