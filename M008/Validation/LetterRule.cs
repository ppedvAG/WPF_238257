using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace M008.Validation;

internal class LetterRule : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string str = value as string;
		if (str.All(char.IsLetter))
			return ValidationResult.ValidResult;
		return new ValidationResult(false, "Der Name darf nur aus Buchstaben bestehen!");
	}
}
