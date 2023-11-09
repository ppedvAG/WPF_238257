using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace M010.Converter;

internal class FourValueToColorConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		byte[] c = values
			.Select(e => (byte) e)
			.ToArray();
		return new SolidColorBrush(Color.FromArgb(c[3], c[0], c[1], c[2]));
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
