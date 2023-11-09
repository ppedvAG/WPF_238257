using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M010;

/// <summary>
/// 3 Werte müssen außen angreifbar sein: Text von dem TextBlock, Farbe vom Text, Value von Slider
/// </summary>
public partial class SliderTextBox : UserControl
{
	public BindableProperty<int> Max { get; set; } = new(255);

	public SliderTextBox()
	{
		InitializeComponent();

		//Mittels GetValue und einer statischen Referenz auf das Property, kann ein Attached Property angegriffen werden
		object maxProp = GetValue(ColorPicker.MaxProperty);
		if (maxProp != null)
			if (maxProp is int x)
				if (x != 0)
					Max.Value = (int) maxProp;
	}

	/// <summary>
	/// propdp -> Tab, Tab
	/// Muss in der UI noch eingebunden werden
	/// Hier ein Binding auf den Textblock, außerhalb kommt der Text
	/// </summary>
	public string Text
	{
		get => (string) GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly DependencyProperty TextProperty =
		DependencyProperty.Register
		(
			nameof(Text), //Namen des Properties
			typeof(string), //Typen des Properties
			typeof(SliderTextBox), //Typ des Besitzers
			new PropertyMetadata("") //Standardwerte des Properties (optional)
		);


	/// <summary>
	/// Color ist nicht direkt kompatibel mit Foreground
	/// Wir benötigen eine SolidColorBrush -> Converter
	/// </summary>
	public Color Color
	{
		get => (Color) GetValue(ColorProperty);
		set => SetValue(ColorProperty, value);
	}

	public static readonly DependencyProperty ColorProperty =
		DependencyProperty.Register(nameof(Color), typeof(Color), typeof(SliderTextBox), new PropertyMetadata(Colors.Black));


	public byte SliderValue
	{
		get => (byte) GetValue(SliderValueProperty);
		set => SetValue(SliderValueProperty, value);
	}

	public static readonly DependencyProperty SliderValueProperty =
		DependencyProperty.Register(nameof(SliderValue), typeof(byte), typeof(SliderTextBox), new PropertyMetadata((byte) 0));


	/// <summary>
	/// Event-Property (mit Add und Remove, effektiv get, set)
	/// Hier kann mittels Generic der Typ des Wertes der beim Event auf der anderen Seite heraus kommt angepasst werden
	/// </summary>
	public event RoutedPropertyChangedEventHandler<byte> SliderValueChanged
	{
		add => AddHandler(SliderValueChangedEvent, value);
		remove => RemoveHandler(SliderValueChangedEvent, value);
	}

	/// <summary>
	/// Sozusagen "Dependency Property" aber für Event
	/// Von außen angreifbar
	/// 
	/// Event Routing: Events werden durch das XAML durchgereicht
	/// Tunneling: Events werden oben nach unten abgearbeitet -> Window, Grid, TextBox, ... (z.B. Preview Events)
	/// Bubbling: Events werden von der Quelle nach oben abgearbeitet -> Button, Grid, Window (z.B. Button Click)
	/// Direct: Events werden einfach ausgegeben -> Element selbst zum Code, diese Events können nicht auf eine höheren/niedrigeren Ebene eingebunden werden
	/// </summary>
	public static readonly RoutedEvent SliderValueChangedEvent =
		EventManager.RegisterRoutedEvent
		(
			nameof(SliderValueChanged),
			RoutingStrategy.Direct,
			typeof(RoutedPropertyChangedEventHandler<byte>), // Hier kann mittels Generic der Typ des Wertes der beim Event auf der anderen Seite heraus kommt angepasst werden
			typeof(SliderTextBox)
		);
}