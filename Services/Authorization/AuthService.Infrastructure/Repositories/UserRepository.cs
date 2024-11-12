using AuthService.Core.Models;
using AuthService.Core.Repositories;
using AuthService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AuthDbContext _authDbContext;

    public UserRepository(AuthDbContext authDbContext)
    {
        _authDbContext = authDbContext;
    }

	public void Create(User user) =>
		_authDbContext.Add(user);

	public void Delete(User user) => 
		_authDbContext.Remove(user);

	public async Task<IEnumerable<User>> GetAllAsync(bool trackChanges = false) =>
		trackChanges ?
		await _authDbContext.Users
		.ToListAsync()
		:
		await _authDbContext.Users
		.AsNoTracking()
		.ToListAsync();

	public async Task<User> GetByIdAsync(Guid id, bool trackChanges = false) =>
		trackChanges ?
		await _authDbContext.Users
		.FirstOrDefaultAsync(u => u.Id.Equals(id))
		:
		await _authDbContext.Users
		.AsNoTracking()
		.FirstOrDefaultAsync(u => u.Id.Equals(id));

	public async Task<User> GetByLoginAsync(string userName, bool trackChanges) =>
		trackChanges ?
		await _authDbContext.Users
		.FirstOrDefaultAsync(u => u.UserName.Equals(userName))
		:
		await _authDbContext.Users
		.AsNoTracking()
		.FirstOrDefaultAsync(u => u.UserName.Equals(userName));

	public void Update(User user) => 
		_authDbContext.Update(user);
}
