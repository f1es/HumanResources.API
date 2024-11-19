using HumanResources.Usecase.Services.Interfaces;
using System.Net.WebSockets;
using System.Text;

namespace HumanResources.Usecase.Services.Implementations;

public class WebLogger : IWebLogger
{
	private WebSocket _webSocket;
	private ILoggerManager _loggerManager;
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

	public async Task LogDebugAsync(string message)
	{
		await LogAsync(message);
		_loggerManager.LogDebug(message);

	}

	public async Task LogErrorAsync(string message)
	{
		await LogAsync(message);
		_loggerManager.LogError(message);
	}

	public async Task LogInfoAsync(string message)
	{
		await LogAsync(message);
		_loggerManager.LogInfo(message);
	}

	public async Task LogWarnAsync(string message)
	{
		await LogAsync(message);
		_loggerManager.LogWarn(message);
	}

	public void UseSocket(WebSocket webSocket)
	{
		_webSocket = webSocket;
	}

    public WebLogger(ILoggerManager loggerManager)
    {
        _loggerManager = loggerManager;
    }
}
