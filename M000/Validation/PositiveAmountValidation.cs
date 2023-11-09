using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace M000.Validation;

internal class PositiveAmountValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		if ((int) value < 0)
			return new ValidationResult(false, "Der Wert darf nicht kleiner als 0 sein!");
		return ValidationResult.ValidResult;
	}
}
