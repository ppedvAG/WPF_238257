using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace M008;

public class Person : INotifyPropertyChanged, IDataErrorInfo
{
	private string vorname;

	public string Vorname
	{
		get => vorname;
		set
		{ 
			vorname = value;
			Notify(nameof(Vorname));
		}
	}


	private string nachname;

	public string Nachname
	{
		get => nachname;
		set
		{
			if (value.Length < 3 || value.Length > 15)
				throw new ArgumentException("Der Nachname muss zwischen 3 und 15 Zeichen enthalten!");

			if (!value.All(char.IsLetter))
				throw new ArgumentException("Der Nachname darf nur aus Buchstaben bestehen!");

			nachname = value;
			Notify(nameof(Nachname));
		}
	}


	private DateTime gebDat;

	public DateTime GebDat
	{
		get => gebDat;
		set
		{
			gebDat = value;
			Notify(nameof(GebDat));
		}
	}


	private bool verheiratet;

	public bool Verheiratet
	{
		get => verheiratet;
		set
		{
			verheiratet = value;
			Notify(nameof(Verheiratet));
		}
	}


	private Color lieblingsfarbe;

	public Color Lieblingsfarbe
	{
		get => lieblingsfarbe;
		set
		{
			lieblingsfarbe = value;
			Notify(nameof(Lieblingsfarbe));
		}
	}

	public string Error => throw new NotImplementedException();

	/// <summary>
	/// Indexer: Ermöglicht, das Objekt mit [] (an der Stelle) anzugreifen
	/// Wird generell bei Listentypen benötigt
	/// Hier wird der Indexer verwendet, um die Validierung durchzuführen
	/// </summary>
	public string this[string columnName]
	{
		get
		{
			switch (columnName)
			{
				case nameof(Vorname): //nameof: Gibt eine String-Repräsentation des Felds zurück (Persistiert zwischen Namensänderungen)
					//if (vorname.Length < 3 || vorname.Length > 15)
					//	return "Der Name muss zwischen 3 und 15 Buchstaben haben!";
					//return null;
					return vorname.Length < 3 || vorname.Length > 15 ? "Der Name muss zwischen 3 und 15 Buchstaben haben!" : null;
				case "Nachname":
					//...
					return null;
			}

			//Wenn dieser Indexer null zurück gibt, ist die Validierung erfolgreich abgeschlossen
			return null;
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string name) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}