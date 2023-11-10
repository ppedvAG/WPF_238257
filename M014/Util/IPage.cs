using System.Windows;

namespace M014.Util;

public interface IPage
{
	public string Title { get; }

	public FrameworkElement Self { get; set; }
}
