using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace M004.Converter;

class FourDoubleToThicknessConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//values ist jetzt ein Array
		double[] d = values.OfType<double>().ToArray();
		return new Thickness(d[0], d[1], d[2], d[3]);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
