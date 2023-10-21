using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoProteccionRepository : GenericRepository<TipoProteccion> , ITipoProteccion
    {
     private readonly AppDbContext _context;
        public TipoProteccionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoProteccion>> GetAllAsync()
{
 return await _context.TiposProteccion.ToListAsync();
}  
}
}