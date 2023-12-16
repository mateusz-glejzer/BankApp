using System.Threading.Tasks;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetAsync(string email);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}