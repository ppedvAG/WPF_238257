using System.ComponentModel;

namespace M013.Model;

public class ModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string property) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
}
