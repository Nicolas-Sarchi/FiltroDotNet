using Domain.Entities;
namespace Domain.Interfaces;

public interface IProveedor : IGenericRepository<Proveedor>
{
    public Task<IEnumerable<Proveedor>> GetPersonasNaturales();
    public   Task<IEnumerable<Proveedor>> GetInsumosProveedor(string id);
}