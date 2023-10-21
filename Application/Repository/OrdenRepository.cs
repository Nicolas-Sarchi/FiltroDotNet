using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class OrdenRepository : GenericRepository<Orden>, IOrden
    {
        private readonly AppDbContext _context;
        public OrdenRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Orden>> GetAllAsync()
        {
            return await _context.Ordenes.ToListAsync();
        }

        public  async Task<IEnumerable<Prenda>> prendasProduccion(int idOrden)
        {
            return await _context.Prendas.Where(o => o.DetallesOrden.Any(o => o.IdOrdenFk == idOrden) && o.IdEstadoFk == 1).Include(o => o.Estado).ToListAsync();
        }

         public  async Task<IEnumerable<Orden>> GetByClienteId(string IdCliente)
         {
            return await _context.Ordenes.Where(o => o.Cliente.IdCliente == IdCliente)
            .Include(o => o.Estado)
            .Include(o => o.Cliente)
            .ThenInclude(c=> c.Municipio)
            .Include(o => o.DetallesOrden)
            .ThenInclude(f => f.Prenda)
            .ToListAsync();
         }

    }
}