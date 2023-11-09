using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace M000;

public class ConverterParameterReferenceExtension : MarkupExtension
{
	private object value;

	public ConverterParameterReferenceExtension(Binding binding)
	{
        Console.WriteLine();
    }

	public override object ProvideValue(IServiceProvider serviceProvider) => value;
}
