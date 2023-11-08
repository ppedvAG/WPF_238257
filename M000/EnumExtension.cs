using System;
using System.Windows.Markup;

namespace M000;

public class EnumExtension : MarkupExtension
{
	private Array elements;

	public EnumExtension(Type enumType) => elements = enumType.IsEnum ? Enum.GetValues(enumType) : null!;

	public override object ProvideValue(IServiceProvider serviceProvider) => elements;
}