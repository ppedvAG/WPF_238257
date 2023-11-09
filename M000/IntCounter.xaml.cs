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

namespace M000;

public partial class IntCounter : UserControl
{
	public IntCounter()
	{
		InitializeComponent();
	}

	public int Count
	{
		get => (int) GetValue(CountProperty);
		set => SetValue(CountProperty, value);
	}

	public static readonly DependencyProperty CountProperty =
		DependencyProperty.Register("Count", typeof(int), typeof(IntCounter), new PropertyMetadata(0));

	private void PlusButton(object sender, RoutedEventArgs e)
	{
		Count++;
    }

	private void MinusButton(object sender, RoutedEventArgs e)
	{
		Count--;
    }
}
