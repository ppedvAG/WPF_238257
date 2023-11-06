using System.Linq;
using System.Windows;

namespace M000;

public partial class MainWindow : Window
{
	public Person Current { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
		//this.DataContext = this;
	}

	private void Ok_Clicked(object sender, RoutedEventArgs e)
	{
		MessageBox.Show(
			Current.GetType()
			.GetProperties()
			.Aggregate(string.Empty, (agg, str) => $"{agg}{str.Name}: {str.GetValue(Current)}\n"),
			"Neue Person", MessageBoxButton.OK, MessageBoxImage.Information);
	}
}
