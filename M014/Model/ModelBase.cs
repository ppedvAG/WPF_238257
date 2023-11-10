using System.ComponentModel;

namespace M014.Model;

public class ModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string property) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
}
