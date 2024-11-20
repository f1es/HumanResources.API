using HumanResources.Core.Models;
using HumanResources.Usecase.Extensions;
using HumanResources.Usecase.Services.Interfaces;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;

namespace HumanResources.Usecase.Services.Implementations;

public class WebLogger : IWebLogger
{
	private WebSocket _webSocket;
	private ILoggerManager _loggerManager;
	public async Task LogAsync(LogAction action)
	{
		try
		{
			if (_webSocket is null)
			{
				throw new ArgumentNullException(nameof(_webSocket));
			}

			if (_webSocket.State == WebSocketState.Open) 
			{
				var logBytes = Encoding.UTF8.GetBytes($"{action.LogType} {action.Username} {action.Message} {action.StatusCode} {action.Date}");
				await _webSocket.SendAsync(new ArraySegment<byte>(logBytes, 0, logBytes.Length), WebSocketMessageType.Text, true, CancellationToken.None); 
			}
		}
		catch
		{

		}
	}

	public async Task LogDebugAsync(string message, int statusCode, IEnumerable<Claim> userClaims)
	{
		var username = userClaims.GetUsername();
		var logAction = new LogAction(username, message, "DEBUG", statusCode);
		await LogAsync(logAction);
		_loggerManager.LogDebug(message);

	}

	public async Task LogErrorAsync(string message, int statusCode, IEnumerable<Claim> userClaims)
	{
		var username = userClaims.GetUsername();
		var logAction = new LogAction(username, message, "ERROR", statusCode);
		await LogAsync(logAction);
		_loggerManager.LogError(message);
	}

	public async Task LogInfoAsync(string message, int statusCode, IEnumerable<Claim> userClaims)
	{
		var username = userClaims.GetUsername();
		var logAction = new LogAction(username, message, "INFO", statusCode);
		await LogAsync(logAction);
		_loggerManager.LogInfo(message);
	}

	public async Task LogWarnAsync(string message, int statusCode, IEnumerable<Claim> userClaims)
	{
		var username = userClaims.GetUsername();
		var logAction = new LogAction(username, message, "WARN", statusCode);
		await LogAsync(logAction);
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
