namespace PBL3_Interface;

public partial class App : Application
{
	public App()
	{

		InitializeComponent();

	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell_Manager());
	}
}