using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace M012;

/// <summary>
/// Execute: Enthält die Funktionalität des Commands
/// CanExecute: Gibt einen bool zurück, der aussagt ob dieses Command gerade ausgeführt werden kann
/// CanExecuteChanged: Event, welches gefeuert werden soll, wenn sich der Zustand von CanExecute ändern soll
/// </summary>
public class DeleteCommand : ICommand
{
	/// <summary>
	/// CanExecuteChanged enthält generell immer CommandManager.RequerySuggested für das System im Hintergrund
	/// </summary>
	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public bool CanExecute(object? parameter)
	{
		if (parameter == null)
			return false;

		TextBox tb = (TextBox) parameter;
		return !string.IsNullOrEmpty(tb.Text);
	}

	public void Execute(object? parameter)
	{
		TextBox tb = (TextBox) parameter;
		tb.Text = "";
	}
}
