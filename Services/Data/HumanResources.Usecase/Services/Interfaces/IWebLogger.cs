using HumanResources.Core.Models;
using System.Net.WebSockets;
using System.Security.Claims;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IWebLogger
{
	Task LogAsync(LogAction action);
	Task LogInfoAsync(string message, int statusCode, IEnumerable<Claim> userClaims);
	Task LogWarnAsync(string message, int statusCode, IEnumerable<Claim> userClaims);
	Task LogDebugAsync(string message, int statusCode, IEnumerable<Claim> userClaims);
	Task LogErrorAsync(string message, int statusCode, IEnumerable<Claim> userClaims);
	void UseSocket(WebSocket webSocket);
}
