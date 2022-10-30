namespace WIlson.JogoDaVelha.Domain.Interfaces;

public interface IBaseCrud<TRequest,TResponse>
{
    Task<IEnumerable<TResponse>> Get();

    Task<TResponse> GetById(int id);

    Task<TResponse> Post(TRequest request);

    Task<TResponse> Put(TRequest request, int? id);

    //Task<List<UsuarioEntities>> Patch();

    Task Delete(int request);
}