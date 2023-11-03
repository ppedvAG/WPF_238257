using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace M004;

public partial class MainWindow : Window
{
	public int Zaehler
	{
		get { return (int) GetValue(ZaehlerProperty); }
		set { SetValue(ZaehlerProperty, value); }
	}

	public static readonly DependencyProperty ZaehlerProperty =
		DependencyProperty.Register
		(
			"Zaehler", //Namen des Properties
			typeof(int), //Type des Properties
			typeof(MainWindow), //Typ der Klasse in dem das Property enthalten ist
			new PropertyMetadata(20) //Standardwert für das Property festlegen (optional)
		);

	public MainWindow()
	{
		InitializeComponent();
		this.DataContext = this; //Hier den DataContext auf das Fenster selbst setzen

		//BindingExpression exp = BindingSlider.GetBindingExpression(TextBox.TextProperty);
		//exp.UpdateTarget();  //Expliziter Befehl zum Updaten
	}

	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		Zaehler = (int) e.NewValue; //Hier wird nur der Wert von dem Slider in das Zaehler Property hineingeschrieben
		//Kein UI Update
	}
}
