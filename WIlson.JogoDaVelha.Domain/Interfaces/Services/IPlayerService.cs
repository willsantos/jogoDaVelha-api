using WIlson.JogoDaVelha.Domain.Contracts.Play;
using WIlson.JogoDaVelha.Domain.Contracts.Player;

namespace WIlson.JogoDaVelha.Domain.Interfaces.Services;

public interface IPlayerService : IBaseCrud<PlayerRequest,PlayerResponse>
{
    
}