namespace PBL3_Interface;

public partial class Manager_MainPage : ContentPage
{
	public Manager_MainPage()
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
	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);

		double baseWidth = 400;
		double scale = Math.Max(0.5, Math.Min(width, height) / baseWidth);

		TitleLabel.FontSize = 25 * scale;

		double horizontalScale = Math.Max(0.5, width / baseWidth); // Tỷ lệ dựa trên chiều ngang
		Resources["NaviHeightRequest"] = 35 * scale;
		Resources["TabMenuHeightRequest"] = 15 * scale;
		Resources["TabMenuWidthRequest"] = 15 * scale;
		Resources["NaviTextFontSize"] = 10 * scale;
		Resources["NaviItemSpacing"] = 2 * horizontalScale;
		Resources["NaviMargin"] = 2 * horizontalScale; // Điều chỉnh Margin theo chiều ngang
		Resources["NaviPadding"] = 5 * horizontalScale;

	}
}


