using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PrendaRepository : GenericRepository<Prenda>, IPrenda
    {
        private readonly AppDbContext _context;
        public PrendaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Prenda>> GetAllAsync()
        {
            return await _context.Prendas.ToListAsync();
        }

        public  async Task<List<IGrouping<string , Prenda>>> PrendasPorTipoDeProteccion()
        {
           return await  _context.Prendas.Include(p => p.Estado).GroupBy(p => p.TipoProteccion.Descripcion).ToListAsync();
        }

        public  async Task<Object> CostoPrenda(string idPrenda)
        {
            return await (Task<object>)_context.Prendas.Where(p => p.IdPrenda == idPrenda)
            .Select(g => new {
                Insumos = g.InsumosPrenda.ToList(),
                CostoPrenda = g.InsumosPrenda.Sum(i => i.Insumo.ValorUnit)
            });
        }

    }
}