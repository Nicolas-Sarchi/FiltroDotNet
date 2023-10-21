using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class VentaRepository : GenericRepository<Venta> , IVenta
    {
     private readonly AppDbContext _context;
        public VentaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Venta>> GetAllAsync()
{
 return await _context.Ventas.ToListAsync();
}  
}
}