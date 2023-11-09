using M000.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace M000.Converter;

public class BooleanToGeschlechtDynamicConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		return (Geschlecht) values[0] == (Geschlecht) parameter;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
