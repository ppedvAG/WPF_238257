using M014.Util;
using M014.View;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace M014.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
	public CustomCommand BeendenCommand { get; set; }

	public CustomCommand NavigatePageCommand { get; set; }

	private IPage currentPage;

	public IPage CurrentPage
	{
		get => currentPage;
		set
		{
			currentPage = value;
			Notify(nameof(CurrentPage));
		}
	}

    public MainWindowViewModel()
    {
		BeendenCommand = new CustomCommand((p) => (p as Window).Close(), (p) => true);
		NavigatePageCommand = new CustomCommand(NavigatePage, (p) => true);
		CurrentPage = new MainPage();
    }

	public void NavigatePage(object page)
	{
		if (page is string str)
		{
			Type newPage = Assembly.GetExecutingAssembly()
								   .GetTypes()
								   .Where(e => e.GetInterface(nameof(IPage)) != null)
								   .First(e => e.Name == str);

			CurrentPage = Activator.CreateInstance(newPage) as IPage;
		}
	}
}
