using System.Windows;

namespace M001;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent(); //Baut den UI (C#) Code aus dem XAML-Code
		//Sollte immer als erstes im Konstruktor stehen

		TestTextBlock.Text = "ABC";
		TestTextBlock.FontSize = 100;
	}
}
