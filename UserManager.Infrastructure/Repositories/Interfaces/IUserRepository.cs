using UserManager.Domain.Entities;

namespace UserManager.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User?> GetAllActive();

        Task<User?> GetByUsernameAsync(string username);
    }
}