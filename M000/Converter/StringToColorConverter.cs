using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace M000.Converter;

public class StringToColorConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		string colorProperty = typeof(Colors)
			.GetProperties()
			.FirstOrDefault(e => (Color) e.GetValue(null) == (Color) value)?
			.Name!;
		return colorProperty;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
}
