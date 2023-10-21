using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TallaRepository : GenericRepository<Talla> , ITalla
    {
     private readonly AppDbContext _context;
        public TallaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Talla>> GetAllAsync()
{
 return await _context.Tallas.ToListAsync();
}  
}
}