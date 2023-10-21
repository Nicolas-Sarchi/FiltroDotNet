using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoPersonaRepository : GenericRepository<TipoPersona> , ITipoPersona
    {
     private readonly AppDbContext _context;
        public TipoPersonaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
{
 return await _context.TiposPersona.ToListAsync();
}  
}
}