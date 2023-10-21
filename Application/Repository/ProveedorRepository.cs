using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
        private readonly AppDbContext _context;
        public ProveedorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public  async Task<IEnumerable<Proveedor>> GetPersonasNaturales()
        {
            return await _context.Proveedores.Where(P => P.IdTipoPersonaFk == 1).Include(p => p.TipoPersona).ToListAsync();
        }
        public  async Task<IEnumerable<Proveedor>> GetInsumosProveedor(string id)
        {
            return await _context.Proveedores.Where(p => p.NitProveedor == id)
            .Include(p => p.Insumos).ToListAsync();
        }


    }
}