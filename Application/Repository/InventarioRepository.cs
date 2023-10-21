using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class InventarioRepository : GenericRepository<Inventario> , IInventario
    {
     private readonly AppDbContext _context;
        public InventarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Inventario>> GetAllAsync()
{
 return await _context.Inventarios.ToListAsync();
}  
}
}