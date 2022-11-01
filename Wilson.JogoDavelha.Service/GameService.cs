using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Game;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Enums;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDavelha.Services;

public class GameService : IGameService
{
    public readonly IGameRepository _gameRepository;
    private readonly IPlayerService _playerService;
    public readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IPlayerService playerService, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _playerService = playerService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GameResponse>> Get()
    {
        var listAllGames = await _gameRepository.Get();
        return _mapper.Map<IEnumerable<GameResponse>>(listAllGames);
    }

    public async Task<GameResponse> GetById(int id)
    {
        var result = await _gameRepository.GetById(id);

        if (result == null)
            throw new Exception("Partida Não Existe");
        return _mapper.Map<GameResponse>(result);
    }

    public async Task<GameResponse> Post(GameRequest request)
    {
        if (request.PlayerA == request.PlayerB)
            throw new ArgumentException("Jogador não pode jogar contra ele mesmo");
        if (!await CheckUserExists(request.PlayerA))
            throw new ArgumentException("Jogador A não está cadastrado, utilize a rota de cadastro");
        if (!await CheckUserExists(request.PlayerB))
            throw new ArgumentException("Jogador B não está cadastrado, utilize a rota de cadastro");

        if (!Enum.IsDefined(typeof(GameStatusEnum), request.Status))
            throw new ArgumentException("Status de partida invalido");


        var gameRequest = _mapper.Map<GameEntity>(request);
        var gamePosted = await _gameRepository.Post(gameRequest);
        return _mapper.Map<GameResponse>(gamePosted);
    }


    public async Task<GameResponse> Put(GameRequest request, int? id )
    {
        var gameInDatabase = await _gameRepository.GetById((int)id);
        gameInDatabase.Status = request.Status;
        var gameCreated = await _gameRepository.Put(gameInDatabase, null);
        return _mapper.Map<GameResponse>(gameCreated);
    }

    public Task Delete(int request)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> CheckUserExists(int player)
    {
        try
        {
            await _playerService.GetById(player);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}