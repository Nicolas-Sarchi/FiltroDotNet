using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DetalleOrdenRepository : GenericRepository<DetalleOrden> , IDetalleOrden
    {
     private readonly AppDbContext _context;
        public DetalleOrdenRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<DetalleOrden>> GetAllAsync()
{
 return await _context.DetallesOrden.ToListAsync();
}  
}
}