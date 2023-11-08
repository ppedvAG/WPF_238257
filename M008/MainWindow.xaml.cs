using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace M008;

public partial class MainWindow : Window
{
	public BindableProperty<string> Vorname { get; set; } = new(null);

	public Person Test { get; set; } = new() { Vorname = "Max" };

	public MainWindow()
	{
		InitializeComponent();
	}
}
