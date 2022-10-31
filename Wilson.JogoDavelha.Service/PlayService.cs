using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Entities;
using WIlson.JogoDaVelha.Domain.Interfaces.Repositories;
using WIlson.JogoDaVelha.Domain.Interfaces.Services;

namespace Wilson.JogoDavelha.Services;

public class PlayService : IPlayService
{
    private readonly IPlayRepository _playRepository;
    private readonly IMapper _mapper;


    public PlayService(IPlayRepository playRepository, IMapper mapper)
    {
        _playRepository = playRepository;
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
        var playEntity = _mapper.Map<PlayEntity>(request);
        var playCreated = await _playRepository.Post(playEntity);
        
        return _mapper.Map<PlayResponse>(playCreated);
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