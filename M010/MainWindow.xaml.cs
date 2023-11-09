using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M010
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			Title += "W";
        }

		private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			Title += "TB";
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Title += "B";
		}

		private void Window_Click(object sender, RoutedEventArgs e)
		{
			Title += "W";
		}

		private void Grid_Click(object sender, RoutedEventArgs e)
		{
			Title += "G";
		}
	}
}
