using System.Net.WebSockets;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IWebLogger
{
	Task LogAsync(string message);
	void UseSocket(WebSocket webSocket);
}
