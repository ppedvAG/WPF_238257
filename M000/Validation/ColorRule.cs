using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace M000.Validation;

public class ColorRule : ValidationRule
{
	public ColorRule() => this.ValidatesOnTargetUpdated = true;

	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		bool colorFound = typeof(Colors)
			.GetProperties()
			.Any(e => e.Name == value);
		if (!colorFound)
			return new ValidationResult(false, "Keine Valide Farbe ausgewählt!");
		return ValidationResult.ValidResult;
	}
}
