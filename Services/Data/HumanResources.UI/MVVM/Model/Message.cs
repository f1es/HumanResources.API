namespace HumanResources.UI.MVVM.Model;

public class Message
{
	public string UserName { get; set; }
	public string Action { get; set; }
	public int StatusCode { get; set; }
	public DateTime Date { get; set; }

	public override string ToString()
	{
		return $"{UserName} do {Action} at {Date} with status code {StatusCode}";
	}
}
