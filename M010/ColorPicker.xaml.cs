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
using System.Windows.Shapes;

namespace M010;

public partial class ColorPicker : Window
{
	public ColorPicker()
	{
		InitializeComponent();
	}

	private void RSlider_SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<byte> e)
	{

	}

	/// <summary>
	/// propa -> Tab, Tab
	/// Ermöglicht, ein "vererbbares" Property anzulegen
	/// Wird an unterliegende Komponente mittels <Name>.<Property> weitergegeben
	/// Beispiel: Grid.Row, Grid.Column
	/// Im Unterelement kann auf dieses Property zugegriffen werden
	/// </summary>
	public static int GetMax(DependencyObject obj)
	{
		return (int) obj.GetValue(MaxProperty);
	}

	public static void SetMax(DependencyObject obj, int value)
	{
		obj.SetValue(MaxProperty, value);
	}

	public static readonly DependencyProperty MaxProperty =
		DependencyProperty.RegisterAttached("Max", typeof(int), typeof(ColorPicker));
}
