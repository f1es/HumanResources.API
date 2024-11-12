using AuthService.Core.Models;

namespace AuthService.Core.Repositories;

public interface IUserRepository
{
	void Delete(User user);
	void Create(User user);
	void Update(User user);
	Task<User> GetByIdAsync(Guid id, bool trackChanges = false);
	Task<User> GetByLoginAsync(string login, bool trackChanges = false);
	Task<IEnumerable<User>> GetAllAsync(bool trackChanges = false);

}
