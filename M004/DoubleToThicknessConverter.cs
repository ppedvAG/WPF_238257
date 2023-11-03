using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace M004;

public class DoubleToThicknessConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//Source -> Target
		//Slider -> Margin
		//Beim Übertragen des Wertes via Binding wird der Converter befragt, wie die Konvertierung erfolgen soll
		double d = (double)value;
		Thickness t = new Thickness(d);
		return t;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//Target -> Source
		//Margin -> Slider (nicht möglich)
		return 0;
	}
}
