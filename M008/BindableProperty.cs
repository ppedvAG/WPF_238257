using System.ComponentModel;

namespace M008;

/// <summary>
/// Diese Klasse ermöglicht ein einzelnes Property zu Erstellen, welches an die UI gebunden werden kann
/// Über das Generic kann ein beliebiger Typ angegeben werden
/// </summary>
/// <typeparam name="T"></typeparam>
public class BindableProperty<T> : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	private T val;

	public T Value
	{
		get => val;
		set
		{
			val = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
		}
	}

	public BindableProperty(T val) => Value = val;
}
