using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ColorRepository : GenericRepository<Color> , IColor
    {
     private readonly AppDbContext _context;
        public ColorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Color>> GetAllAsync()
{
 return await _context.Colores.ToListAsync();
}  
}
}