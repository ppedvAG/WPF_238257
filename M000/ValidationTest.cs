using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace M000;

public class ValidationTest : MarkupExtension
{
	private Binding binding;

    public ValidationTest(Binding binding, params ValidationRule[] rules)
    {
		this.binding = binding;
		foreach (ValidationRule rule in rules)
		{
			binding.ValidationRules.Add(rule);
		}
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return binding.ProvideValue(serviceProvider);
	}
}
