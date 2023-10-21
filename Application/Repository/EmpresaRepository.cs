using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class EmpresaRepository : GenericRepository<Empresa> , IEmpresa
    {
     private readonly AppDbContext _context;
        public EmpresaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Empresa>> GetAllAsync()
{
 return await _context.Empresas.ToListAsync();
}  
}
}