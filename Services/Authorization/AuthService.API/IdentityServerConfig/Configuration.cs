using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace AuthService.API.IdentityServerConfig;

public static class Configuration
{
	public static IEnumerable<Client> GetClients() =>
		new List<Client>
		{
			new Client
			{
				ClientId = "wpf_client",
				AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
				RequireClientSecret = false,
				AccessTokenLifetime = 60 * 60 * 24,
				AllowedScopes = 
				{ 
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					"api1"
				},
			}
		};

	public static IEnumerable<ApiResource> GetApiResources() =>
		new List<ApiResource>
		{
			new ApiResource("api1", "HumanResources API")
			{
				Scopes = { "api1" },
			}
		};

	public static IEnumerable<ApiScope> GetApiScopes() =>
		new List<ApiScope>
		{
			new ApiScope("api1", "HumanResources API", []),
		};

	public static IEnumerable<IdentityResource> GetIdentityResources() =>
		new List<IdentityResource>
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
		};
}
