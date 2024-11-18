using FlesLib.WPF;
using HumanResources.UI.MVVM.Model;

namespace HumanResources.UI.MVVM.ViewModel;

public class MainWindowViewModel : ObservableObject
{
	private List<Message> _messages = new List<Message>()
	{ 
		new Message()
		{
			UserName = "User",
			Action = "call GetByIdAsync in WorkersController ",
			Date = DateTime.Now,
			StatusCode = 200,
		}
	};

	public List<Message> Messages
	{
		get => _messages;
		set
		{
			_messages = value;
			OnPropertyChanged();
		}
	}
}
