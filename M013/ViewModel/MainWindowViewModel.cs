using M013.Model;
using M013.Util;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace M013.ViewModel;

/// <summary>
/// Hier im ViewModel können jetzt die Standarddinge gemacht werden, die auch in den normalen Backend Klassen funktioniert (MainWindow.xaml.cs)
/// </summary>
public class MainWindowViewModel : ViewModelBase //Empfehlenswert für INotifyPropertyChanged
{
	public ObservableCollection<Person> Personen { get; set; } = new();

	public CustomCommand CreatePersonCommand { get; set; }

	/// <summary>
	/// Wenn das ViewModel als DataContext gesetzt wird, wird von dieser Klasse ein Objekt erstellt
	/// </summary>
    public MainWindowViewModel()
    {
		CreatePersonCommand = new CustomCommand(CreatePersonClicked, (p) => true);
    }

	public void CreatePersonClicked(object parameter)
	{
		Person p = new Person();
		char[] characters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
		p.ID = Personen.Count;
		p.Vorname = new string(Enumerable.Range(0, 10).Select(e => characters[Random.Shared.Next(0, characters.Length)]).ToArray());
		p.Nachname = new string(Enumerable.Range(0, 10).Select(e => characters[Random.Shared.Next(0, characters.Length)]).ToArray());
		Personen.Add(p);
	}
}