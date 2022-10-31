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

        if(!await CheckPlayerInGame(request.PlayerId, request.GameId))
            throw new ArgumentException("Jogador não está nessa partida");
        
        if (!await CheckPositionIsValid(request.Position, request.GameId))
            throw new ArgumentException("Posição Invalida");
        
        if (!await CheckTurn(request.PlayerId, request.GameId))
            throw new Exception("Não é a vez desse jogador");
        
        var playEntity = _mapper.Map<PlayEntity>(request);
        var playCreated = await _playRepository.Post(playEntity);
        
        return _mapper.Map<PlayResponse>(playCreated);
    }

    private async Task<bool> CheckTurn(int playerId, int gameId)
    {
        var lastplay = await _playRepository.GetLastPlay(gameId);
        if (lastplay == null)
            return true;
        if(lastplay.PlayerId == playerId)
            return false;
        return true;
        
    }

    private async Task<bool> CheckPositionIsValid(string requestPosition, int gameId)
    {
        
        var position = requestPosition.Split(",")?.Select(Int32.Parse)?.ToArray();

        if (position[0] > 3 || position[0] < 1 || position[1] > 3 || position[1] < 1 || position.Length<1)
            return false;
        var plays = await GetPlayByGameId(gameId);
        foreach (var item in plays)
        {
           var newPosition= string.Join(",", position);

           if (item.Position == newPosition)
               return false;
        }

        return true;
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