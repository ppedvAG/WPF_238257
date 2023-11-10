using System;
using System.Windows.Input;

namespace M012;

/// <summary>
/// CustomCommand: Soll alle möglichen Commands halten können
/// -> Normalerweise wird eine Klasse pro Command benötigt. Das werden über Zeit sehr viele Klassen
/// Über zwei Methodenzeiger können Execute und CanExecute hier gespeichert werden
/// </summary>
public class CustomCommand : ICommand
{
	private Action<object> execute;

	private Func<object, bool> canExecute;

	/// <summary>
	/// Action: Methodenzeiger mit void als Rückgabetyp und bis zu 16 Parameter
	/// Über das Generic (hier object) kann ein Parameter definiert werden
	/// Die Execute Action soll an der Execute Methode angehängt werden
	/// Deshalb benötigt die Action die selbe Struktur wie Execute selbst
	/// 
	/// Func: Selbiges wie Action, aber hat einen Rückgabetyp
	/// Das letzte Generic ist der Rückgabetyp (hier bool)
	/// </summary>
	public CustomCommand(Action<object> execute, Func<object, bool> canExecute)
	{
		this.execute = execute;
		this.canExecute = canExecute;
	}

	/// <summary>
	/// Hier wird die Execute Action ausgeführt
	/// </summary>
	public void Execute(object? parameter) => execute(parameter); //Führe die Methode aus, die an der execute Variable angehängt ist aus

	public bool CanExecute(object? parameter) => canExecute(parameter);

	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}
}
