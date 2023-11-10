using System.ComponentModel;
using System.Windows;

namespace M014.ViewModel;

public class ViewModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string property) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

	private FrameworkElement self;

	public FrameworkElement Self
	{
		get => self;
		set
		{
			self = value;
			Notify(nameof(Self));
		}
	}
}