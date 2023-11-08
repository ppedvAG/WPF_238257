using System;
using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

internal class LengthRule : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string str = value as string;
		if (str == null || str.Length < 3 || str.Length > 15)
			return new ValidationResult(false, "Name muss zwischen 3 und 15 Zeichen lang sein!");
		return ValidationResult.ValidResult;
	}
}
