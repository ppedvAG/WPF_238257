using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace M005;

public partial class MainWindow : Window
{
	//public double SliderValue { get; set; }
	public BindableProperty<double> SliderValue { get; set; } = new BindableProperty<double>(0);

	public Person Person { get; set; } = new Person() { Vorname = "Max", Nachname = "Mustermann", Alter = 20 };

	/// <summary>
	/// ObservableCollection: List, die INotifyCollectionChanged implementiert um die UI zu benachrichtigen
	/// WICHTIG: Die Inhalte selbst benachrichtigen nicht
	/// </summary>
	public ObservableCollection<Person> PersonenListe { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
		//this.DataContext = this;
	}

	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		//Wert vom Slider einfach in die Variable schreiben
		//Kein UI Update
		SliderValue.Value = (double) e.NewValue;
	}

	/// <summary>
	/// Wenn der Button geklickt: Alter + 1, Setzen des private Felds dahinter, Benachrichtigen der UI, UI macht das Update
	/// Wenn der Button geklickt: Person wird hinzugefügt, Collection benachrichtigt UI, UI macht das Update
	/// </summary>
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Person.Alter++;
		PersonenListe.Add(new Person() { Vorname = "Max", Nachname = "Mustermann", Alter = Random.Shared.Next(20, 100) });
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		for (int i = 0; i <  PersonenListe.Count; i++)
			PersonenListe[i].Alter = Random.Shared.Next(20, 100);
	}
}
