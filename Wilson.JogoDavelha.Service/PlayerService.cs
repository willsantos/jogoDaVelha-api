using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Contracts.Player;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDavelha.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PlayerResponse>> Get()
    {
        var listAllPlayers = await _playerRepository.Get();
        return _mapper.Map<IEnumerable<PlayerResponse>>(listAllPlayers);
    }

    public Task<PlayerResponse> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PlayerResponse> Post(PlayerRequest request)
    {
        var playerRequest = _mapper.Map<PlayerEntity>(request);
        var playerPosted = await _playerRepository.Post(playerRequest);
        return _mapper.Map<PlayerResponse>(playerPosted);
    }

    public Task<PlayerResponse> Put(PlayerRequest request, int? id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int request)
    {
        throw new NotImplementedException();
    }
}