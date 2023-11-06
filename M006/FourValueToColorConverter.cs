using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace M006
{
	internal class FourValueToColorConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			byte[] c = values
				.OfType<double>()
				.Select(e => (byte) e)
				.ToArray();
			return new SolidColorBrush(Color.FromArgb(c[3], c[0], c[1], c[2]));
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
	}
}
