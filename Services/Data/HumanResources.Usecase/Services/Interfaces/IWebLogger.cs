using System.Net.WebSockets;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IWebLogger
{
	Task LogAsync(string message);
	Task LogInfoAsync(string message);
	Task LogWarnAsync(string message);
	Task LogDebugAsync(string message);
	Task LogErrorAsync(string message);
	void UseSocket(WebSocket webSocket);
}
