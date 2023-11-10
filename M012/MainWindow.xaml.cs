using System.ComponentModel;
using System.Windows;

namespace M012;

public partial class MainWindow : Window, INotifyPropertyChanged
{
	public DeleteCommand Delete { get; set; } = new DeleteCommand();

	public CustomCommand CustomDelete { get; set; }

	public CustomCommand EnterCommand { get; set; }

	private string text;

	public string Text
	{
		get => text;
		set
		{
			text = value;
			Notify(nameof(Text));
			TextBoxDeleteCanExecute = CustomDelete.CanExecute(TB);
			//Delete.CanExecuteChanged(this, EventArgs.Empty);
		}
	}

	private bool canExe;

	public bool TextBoxDeleteCanExecute
	{
		get => canExe;
		set
		{
			canExe = value;
			Notify(nameof(TextBoxDeleteCanExecute));
		}
	}

	public MainWindow()
	{
		InitializeComponent();
		//Hier Command erstellen mit separaten Methoden
		//CustomDelete = new CustomCommand
		//(
		//	//Hier müssen zwei Methodenzeiger übergeben werden
		//	DeleteAction,
		//	DeleteFunc
		//);

		//Hier Command erstellen mit anonymen Methoden
		CustomDelete = new CustomCommand
		(
			//Hier müssen zwei Methodenzeiger übergeben werden
			(parameter) => Text = "", //Execute
			(parameter) => true //CanExecute
		);

		EnterCommand = new CustomCommand
		(
			(parameter) => Output.Text = "Test",
			(p) => true //parameter und p sind hier nur Namen
		);
	}

	//public void DeleteAction(object parameter)
	//{

	//}

	//public bool DeleteFunc(object parameter)
	//{
	//	return true;
	//}


	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string name) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
