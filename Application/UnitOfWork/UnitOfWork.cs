using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;
    public class UnitOfWork : IUnitOfWork

    {
        private readonly AppDbContext context;
        private RoleRepository _roles;
        private UserRepository _Users;

        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
        }

        public IUser Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(context);
                }
                return _Users;
            }
        }
        public IRole Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RoleRepository(context);
            }
            return _roles;
        }
    }

        public int Save()
        {
            return context.SaveChanges();
        }
         public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

        public void Dispose()
        {
            context.Dispose();
        }
    }