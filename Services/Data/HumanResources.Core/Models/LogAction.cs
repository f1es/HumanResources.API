namespace HumanResources.Core.Models;

public class LogAction
{
	public string Username { get; set; }
	public string LogType { get; set; }
	public string Message { get; set; }
	public int StatusCode { get; set; }
	public DateTime Date { get; set; }

    public LogAction(string username, string message, string logType, int satatusCode)
    {
        Username = username;
		LogType = logType;
		Message = message;
		StatusCode = satatusCode;
		Date = DateTime.Now;
    }
}
