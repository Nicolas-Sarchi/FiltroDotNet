using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly AppDbContext _context;
        public EmpleadoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<IEnumerable<Empleado>> GetFacturaEmpleado(string idEmpleado)
        {
            return await _context.Empleados.Where(e => e.IdEmpleado == idEmpleado)
            .Include(e => e.Ventas).ToListAsync();
        }
    }
}