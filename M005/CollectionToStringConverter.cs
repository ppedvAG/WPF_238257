using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace M005;

public class CollectionToStringConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		IEnumerable<object> x = (IEnumerable<object>) value;
		StringBuilder sb = new();
		sb.Append("[");
		foreach (object item in x)
		{
			sb.Append(item.ToString() + ", ");
		}
		sb.Append("]");
		return sb.ToString();
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
