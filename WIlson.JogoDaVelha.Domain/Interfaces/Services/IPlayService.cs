using WIlson.JogoDaVelha.Domain.Contracts.Play;

namespace WIlson.JogoDaVelha.Domain.Interfaces.Services;

public interface IPlayService: IBaseCrud<PlayRequest,PlayResponse>
{
    Task<IEnumerable<PlayResponse>>GetPlayByGameId(int id);
}