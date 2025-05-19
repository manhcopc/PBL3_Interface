namespace PBL3_Interface;

public partial class App : Application
{
	public App()
	{

		InitializeComponent();

	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new Pages.AccountCashierPage());
	}
}
// find . -name "obj" -exec rm -rf {} +
// find . -name "bin" -exec rm -rf {} +
// find . -name ".vs" -exec rm -rf {} +
// dotnet restore
// dotnet build -f net9.0-maccatalyst