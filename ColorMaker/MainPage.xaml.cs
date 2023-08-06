using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	int count = 0;

    public string HexValue { get; private set; }

    public MainPage()
	{
		InitializeComponent();
	}

	private void Slider_ValueChanged(object sender, EventArgs e)
	{
		var red = sldRed.Value;
		var green = sldGreen.Value;
		var blue = sldBlue.Value;

		Color color = Color.FromRgb(red, green, blue);

		SetColor(color);
	}

    private void SetColor(Color color)
    {
		Debug.WriteLine(color.ToString());
        btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		HexValue = color.ToHex();
		lblHex.Text = HexValue;
    }

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		var random = new Random();
		var color = Color.FromRgb
			(
				random.Next(0, 265),
				random.Next(0,265),
				random.Next(0, 265)
			);

		SetColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(HexValue);
		var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
		await toast.Show();
	}
}

