using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M010.Converter;

public class ColorToBrushConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => new SolidColorBrush((Color) value);

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ((SolidColorBrush) value).Color;
}
