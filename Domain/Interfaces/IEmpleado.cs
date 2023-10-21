using Domain.Entities;
namespace Domain.Interfaces;

public interface IEmpleado : IGenericRepository<Empleado>
{
    public  Task<IEnumerable<Empleado>> GetFacturaEmpleado(string idEmpleado);
}