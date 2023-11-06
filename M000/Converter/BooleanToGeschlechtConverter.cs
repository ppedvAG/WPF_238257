using M000.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace M000.Converter;

public class BooleanToGeschlechtConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (bool) value ? parameter : Binding.DoNothing;
	}
}
