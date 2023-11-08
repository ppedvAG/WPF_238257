using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace M000;

public class ValidationMarkupExtension : MarkupExtension
{
	private Binding binding;

	/// <summary>
	/// Über den Konstruktor kann hier festgelegt werden, welche Werte im XAML übergeben werden können
	/// Dieser Konstruktor soll ein Binding empfangen und die entsprechende Regeln
	/// </summary>
    public ValidationMarkupExtension(Binding binding, ValidationRuleCollection coll)
    {
		foreach (ValidationRule rule in coll)
		{
			binding.ValidationRules.Add(rule);
		}
		this.binding = binding;
    }

	/// <summary>
	/// Diese Methode ermöglicht das zurückgeben von einem Wert innerhalb des XAMLs
	/// Wird benötigt, um die MarkupExtension auszuführen
	/// Hier können wir das Binding auffordern, seinen Wert zurückzugeben
	/// </summary>
    public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return binding.ProvideValue(serviceProvider);
	}
}
