namespace AuthService.Core.Repositories;

public interface IRepositoryManager
{
	public IUserRepository UserRepository { get; }

	public Task SaveAsync();
}
