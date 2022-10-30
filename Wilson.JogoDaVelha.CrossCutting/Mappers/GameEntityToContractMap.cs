using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Game;
using WIlson.JogoDaVelha.Domain.Entities;

namespace Wilson.JogoDaVelha.CrossCutting.Mappers;

public class GameEntityToContractMap : Profile
{
    public GameEntityToContractMap()
    {
        CreateMap<GameEntity, GameRequest>().ReverseMap();
        CreateMap<GameEntity, GameResponse>().ReverseMap();
        
        
    }
}