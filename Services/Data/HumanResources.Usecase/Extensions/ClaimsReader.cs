using System.Security.Claims;

namespace HumanResources.Usecase.Extensions;

public static class ClaimsReader
{
	public static string GetUsername(this IEnumerable<Claim> claims)
	{
		var usernameClaim = claims.FirstOrDefault(c => c.Type == "name");
		if (usernameClaim is null)
		{
			return "none";
		}
		else
		{
			return usernameClaim.Value;
		}
	}
}
