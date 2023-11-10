using System.Windows;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace M015;

public partial class MainWindow : Window
{
	public ObservableCollection<object[]> Products { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
	}


	/// <summary>
	/// Dauernde Arbeit blockiert die UI
	/// -> Async/Await
	/// </summary>
	private void Button_Click1(object sender, RoutedEventArgs e)
	{
		using SqlConnection con = new SqlConnection("Server=WIN10-LK3;Database=Northwind;Trusted_Connection=True;");
		con.Open();
		SqlCommand sqlCommand = con.CreateCommand();
		sqlCommand.CommandText = "SELECT * FROM Products";
		SqlDataReader reader = sqlCommand.ExecuteReader();
		while (reader.Read())
		{
			object[] fields = new object[reader.FieldCount];
			reader.GetValues(fields);
			Products.Add(fields);
		}
		Thread.Sleep(2000);
	}

	/// <summary>
	/// async: Diese Methode wird parallel zum Main Thread ausgeführt -> Main Thread wird nicht mehr blockiert
	/// Bei jeder Methode die etwas länger dauern würde, kann jetzt die entsprechende Asnyc Methode verwendet werden
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		using SqlConnection con = new SqlConnection("Server=WIN10-LK3;Database=Northwind;Trusted_Connection=True;");
		// await con.OpenAsync(); //...Async: Diese Methode wird gestartet aber parallel, heißt diese Methode macht ihre Sache und währenddessen geht es im Hintergrund weiter
							   //await: Warte hier, das diese Methode fertig wird

		Task open = con.OpenAsync(); //Starte das Öffnen
		Status.Text = "Verbindung wird geöffnet";
		await open; //Warte bis das Öffnen fertig ist


		using (SqlCommand command2 = con.CreateCommand())
		{
			command2.CommandText = "SELECT COUNT(*) FROM Products";
			object result = await command2.ExecuteScalarAsync();
			Progress.Maximum = (int) result;
		}

		using SqlCommand sqlCommand = con.CreateCommand(); //Kein Async verfügbar
		sqlCommand.CommandText = "SELECT * FROM Products";


		Task<SqlDataReader> readerTask = sqlCommand.ExecuteReaderAsync(); //Hier wurde nur der Reader initialisiert (noch keine Daten gelesen)
		Status.Text = "Reader wird initialisiert";
		SqlDataReader reader = await readerTask;

		while (await reader.ReadAsync()) //Warte mit await bei jedem Schleifendurchlauf auf die nächste Row
		{
			object[] fields = new object[reader.FieldCount];
			reader.GetValues(fields);
			Products.Add(fields);
			await Task.Delay(10); //Künstliches Delay
			Progress.Value++;
		}
	}
}
