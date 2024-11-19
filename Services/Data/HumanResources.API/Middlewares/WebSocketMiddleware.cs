using HumanResources.Usecase.Services.Implementations;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Text;

namespace HumanResources.API.Middlewares;

public class WebSocketMiddleware
{
	private readonly RequestDelegate _next;
	private readonly IWebLogger _webLogger;

	public WebSocketMiddleware(RequestDelegate next, IWebLogger webLogger)
	{
		_next = next;
		_webLogger = webLogger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		if (context.Request.Path == "/ws")
		{
			if (context.WebSockets.IsWebSocketRequest)
			{
				var webSocket = await context.WebSockets.AcceptWebSocketAsync();
				_webLogger.UseSocket(webSocket);
				await HandleWebSocketAsync(context, webSocket);
			}
			else
			{
				context.Response.StatusCode = 400;
			}
		}
		else
		{
			await _next(context);
		}
	}

	private async Task HandleWebSocketAsync(HttpContext context, WebSocket webSocket)
	{
		var buffer = new byte[1024 * 4];
		WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
		while (!result.CloseStatus.HasValue)
		{
			var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
			await _webLogger.LogAsync(message);

			result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
		}
		await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
	}
}
