namespace M013.Model;

public class Person : ModelBase //Empfehlenswert für INotifyPropertyChanged
{
	private int id;

	public int ID
	{
		get => id;
		set
		{
			id = value;
			Notify(nameof(ID));
		}
	}

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
			nachname = value;
			Notify(nameof(Nachname));
		}
	}
}