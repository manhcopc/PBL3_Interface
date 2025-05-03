namespace PBL3_Interface;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		try
		{
			InitializeComponent();
			System.Diagnostics.Debug.WriteLine("MainPage initialized successfully");
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine($"Error initializing MainPage: {ex.Message}\nStackTrace: {ex.StackTrace}");
			throw;
		}
	}
}


