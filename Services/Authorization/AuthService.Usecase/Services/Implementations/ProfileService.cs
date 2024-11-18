using AuthService.Core.Models;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AuthService.Usecase.Services.Implementations;

public class ProfileService : IProfileService
{
	private readonly UserManager<User> _userManager;
    public ProfileService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
	{
		var user = await _userManager.GetUserAsync(context.Subject);
		if (user is null)
		{
			throw new Exception("User not found");
		}

		var claims = new List<Claim>()
		{
			new Claim(JwtClaimTypes.Name, user.UserName)
		};

		context.IssuedClaims.AddRange(claims);
	}

	public async Task IsActiveAsync(IsActiveContext context)
	{
		var user = await _userManager.GetUserAsync(context.Subject);
		context.IsActive = user != null;
	}
}
