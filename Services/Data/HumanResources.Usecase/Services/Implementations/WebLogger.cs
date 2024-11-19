using HumanResources.Usecase.Services.Interfaces;
using System.Net.WebSockets;
using System.Text;

namespace HumanResources.Usecase.Services.Implementations;

public class WebLogger : IWebLogger
{
	private WebSocket _webSocket;
	public async Task LogAsync(string message)
	{
		if (_webSocket is null)
		{
			throw new ArgumentNullException(nameof(_webSocket));
		}

		if (_webSocket.State == WebSocketState.Open) 
		{
			var logBytes = Encoding.UTF8.GetBytes(message);
			await _webSocket.SendAsync(new ArraySegment<byte>(logBytes, 0, logBytes.Length), WebSocketMessageType.Text, true, CancellationToken.None); 
		}
	}
	public void UseSocket(WebSocket webSocket)
	{
		_webSocket = webSocket;
	}
}
