using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DetalleVentaRepository : GenericRepository<DetalleVenta> , IDetalleVenta
    {
     private readonly AppDbContext _context;
        public DetalleVentaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<DetalleVenta>> GetAllAsync()
{
 return await _context.DetallesVenta.ToListAsync();
}  
}
}