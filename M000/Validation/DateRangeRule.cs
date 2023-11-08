using System;
using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

public class DateRangeRule : ValidationRule
{
	public DateRangeRule() => ValidatesOnTargetUpdated = true;

	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		DateTime dt = (DateTime)value;
		if (dt >= DateTime.Today)
			return new ValidationResult(false, "Das Datum darf nicht in der Zukunft liegen!");
		if (dt <= new DateTime(1900, 1, 1))
			return new ValidationResult(false, "Das Datum darf nicht kleiner als 1900 sein!");
		return ValidationResult.ValidResult;
	}
}
