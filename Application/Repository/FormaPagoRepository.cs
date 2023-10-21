using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class FormaPagoRepository : GenericRepository<FormaPago> , IFormaPago
    {
     private readonly AppDbContext _context;
        public FormaPagoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<FormaPago>> GetAllAsync()
{
 return await _context.FormasPago.ToListAsync();
}  
}
}