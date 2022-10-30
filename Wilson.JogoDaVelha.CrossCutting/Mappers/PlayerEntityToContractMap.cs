using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Player;
using WIlson.JogoDaVelha.Domain.Entities;

namespace Wilson.JogoDaVelha.CrossCutting.Mappers;

public class PlayerEntityToContractMap : Profile
{
    public PlayerEntityToContractMap()
    {
        CreateMap<PlayerEntity, PlayerRequest>().ReverseMap();
        CreateMap<PlayerEntity, PlayerResponse>().ReverseMap();
    }
}