using AuthService.Core.Repositories;
using AuthService.Infrastructure.Context;

namespace AuthService.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private AuthDbContext _authDbContext;
    private Lazy<IUserRepository> _userRepository;
    public RepositoryManager(AuthDbContext authDbContext)
    {
        _authDbContext = authDbContext;

        _userRepository = new Lazy<IUserRepository>(() => 
        new UserRepository(authDbContext));
    }

    public IUserRepository UserRepository => 
        _userRepository.Value;

    public async Task SaveAsync() => 
        await _authDbContext.SaveChangesAsync();
}
