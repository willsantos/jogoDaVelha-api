using AutoMapper;
using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Entities;

namespace Wilson.JogoDaVelha.CrossCutting.Mappers;

public class PlayEntityToContractMap : Profile
{
    public PlayEntityToContractMap()
    {
        CreateMap<PlayEntity, PlayRequest>().ReverseMap();
        CreateMap<PlayEntity, PlayResponse>().ReverseMap();
    }
}