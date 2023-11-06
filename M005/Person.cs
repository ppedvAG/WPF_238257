using System.ComponentModel;

namespace M005;

public class Person : INotifyPropertyChanged
{
	private string vorname;

	public string Vorname
	{
		get => vorname;
		set
		{ 
			vorname = value;
			Notify(nameof(Vorname)); //nameof: Gibt den Namen der gegebenen Variable als String zurück
		}
	}


	/// <summary>
	/// Property generieren mit propfull Snippet
	/// oder
	/// Strg + . -> Convert to full property
	/// </summary>
	private string nachname;

	public string Nachname
	{
		get => nachname;
		set
		{
			nachname = value;
			Notify(nameof(Nachname));
		}
	}


	private int alter;

	public int Alter
	{
		get => alter;
		set
		{
			alter = value;
			Notify(nameof(Alter));
		}
	}

	/// <summary>
	/// Dieses Event wird von der UI selbst angebunden, wir müssen es nur aufrufen
	/// </summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Null Propagation (? Operator): Wenn das Objekt nicht null ist, führe den Code danach aus, sonst mach nichts
	/// </summary>
	public void Notify(string name) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

	public override string ToString()
	{
		return $"{Vorname} {Nachname}, {Alter} Jahre alt";
	}
}