using System.Text.Json;

namespace HumanResources.Usecase.NamingPolicies;

public class PascalCaseNamingPolicy : JsonNamingPolicy
{
	public override string ConvertName(string name)
	{
		return char.ToUpper(name[0]) + name.Substring(1);
	}
}
