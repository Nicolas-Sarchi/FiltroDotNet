using Domain.Entities;
namespace Domain.Interfaces;

public interface IPrenda : IGenericRepository<Prenda>
{
    public Task<List<IGrouping<string , Prenda>>> PrendasPorTipoDeProteccion();
    public   Task<Object> CostoPrenda(string idPrenda);
}