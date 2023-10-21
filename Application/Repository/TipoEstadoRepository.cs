using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoEstadoRepository : GenericRepository<TipoEstado> , ITipoEstado
    {
     private readonly AppDbContext _context;
        public TipoEstadoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoEstado>> GetAllAsync()
{
 return await _context.TiposEstado.ToListAsync();
}  
}
}