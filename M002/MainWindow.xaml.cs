using System.Windows;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Controls;
using System;

namespace M002;

public partial class MainWindow : Window
{
	public int Zaehler { get; set; }

	public MainWindow()
	{
		InitializeComponent();
		List<string> strings = new(); //ItemsSource kann ein beliebiges IEnumerable sein (z.B. string Liste, Personen Liste aus Datenbank, ...)
		strings.Add("Text1");
		strings.Add("Text2");
		strings.Add("Text3");
		strings.Add("Text4");
		strings.Add("Text5");
		CB.ItemsSource = strings;

		//Enumwerte in eine ItemsSource eintragen
		CB.ItemsSource = Enum.GetValues<DayOfWeek>();

		//Komplexe Objektliste in ItemsSource eintragen
		List<Person> personen = new();
		personen.Add(new Person("Max", "Muster", 23));
		personen.Add(new Person("Max", "Muster", 34));
		personen.Add(new Person("Max", "Muster", 45));
		CB.ItemsSource = personen; //Hier wird in der UI die ToString() Methode des entsprechenden Objekts ausgeführt

		LB.ItemsSource = personen;
	}

	private void ZaehlerPlusPlus(object sender, RoutedEventArgs e)
	{
		Zaehler++;
		TB.Text = Zaehler.ToString();

		//Show: Zeigt ein neues Fenster
		//ShowDialog: Zeigt ein neues Fenster, blockiert den Hintergrund
		//ShowDialog kann auch ein Ergebnis haben
		new MainWindow().Show();
		bool? b = new MainWindow().ShowDialog();
		DialogResult = true;
		//Über die Globale Variable DialogResult kann das Ergebnis eines Dialogs zurückgegeben werden
		//Das Ergebnis wird zurückgegeben wenn der Dialog geschlossen wird
		if (b.Value)
		{
			//...
			//Application.Current.MainWindow //Hauptfenster der Applikation angreifen
			Environment.Exit(0);
		}

		MessageBoxResult result = MessageBox.Show("Möchtest du was tun?", "Frage", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (result == MessageBoxResult.Yes) //Hier muss auf die gegebenen Buttons geachtet werden: YesNo != OKCancel
		{
			//...
		}
	}

	private void Eingabe_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			TB.Text = Eingabe.Text;
		}
	}

	private void Eingabe_PreviewKeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			TB.Text = Eingabe.Text;
			e.Handled = true; //e.Handled: Beendet das Event
		}
	}

	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		ComboBox dropdown = sender as ComboBox;
		if (dropdown != null)
		{
			TB.Text = dropdown.SelectedItem.ToString(); //SelectedItem ist anhand der ItemsSource der gegebene Typ
		}
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		if (this.IsInitialized) //Hier erfragen, ob die UI bereits fertig erzeugt wurde
			TB.Text = "Checkbox checked";
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		if (this.IsInitialized)
			TB.Text = "Checkbox unchecked";
	}

	private void S_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		if (!IsInitialized)
			return;

		Slider s = sender as Slider;
		if (s != null)
		{
			//TB.Text = s.Value.ToString();
			Progress.Value = s.Value;
		}
	}

	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		ListBox lb = sender as ListBox;
		string output = "[";
		foreach (ListBoxItem item in lb.SelectedItems)
			output += item.Content;
		output += "]";
		TB.Text = output;
	}
}

//public record Person(string Vorname, string Nachname, int Alter); //Einzeiler von dem unteren Code

public class Person
{
	public string Vorname { get; set; }

	public string Nachname { get; set; }

	public int Alter { get; set; }

	public Person(string vorname, string nachname, int alter)
	{
		Vorname = vorname;
		Nachname = nachname;
		Alter = alter;
	}

	public override string ToString()
	{
		return $"{Vorname} {Nachname}, {Alter} Jahre alt";
	}
}