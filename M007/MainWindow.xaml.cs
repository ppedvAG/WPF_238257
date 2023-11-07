using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace M007;

public partial class MainWindow : Window
{
	public ObservableCollection<Person> Personen { get; set; } = new()
	{
		new Person(){ ID = 0, Name = "Max", Description = "Person1" },
		new Person(){ ID = 1, Name = "Max2", Description = "Person2"},
		new Person(){ ID = 2, Name = "Max3", Description = "Person3"}
	};

	public MainWindow()
	{
		InitializeComponent();
	}

	private void ControlTemplate_Click(object sender, RoutedEventArgs e)
	{
		Close();
	}
}
