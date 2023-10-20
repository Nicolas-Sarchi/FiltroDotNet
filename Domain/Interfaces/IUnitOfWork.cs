namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRole Roles { get; }
    IUser Users { get; }
    Task<int> SaveAsync();
}