using Domain.Entities;
namespace Domain.Interfaces;

public interface IOrden : IGenericRepository<Orden>
{
    public Task<IEnumerable<Prenda>> prendasProduccion(int idOrden);
    public   Task<IEnumerable<Orden>> GetByClienteId(string IdCliente);
}