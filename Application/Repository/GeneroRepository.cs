using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class GeneroRepository : GenericRepository<Genero> , IGenero
    {
     private readonly AppDbContext _context;
        public GeneroRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Genero>> GetAllAsync()
{
 return await _context.Generos.ToListAsync();
}  
}
}