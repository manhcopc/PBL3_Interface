using PBL3_Interface.Pages;
namespace PBL3_Interface;

public partial class AppShell_Manager : Shell
{
	public AppShell_Manager()
	{
		InitializeComponent();
		System.Diagnostics.Debug.WriteLine("AppShell_Manager initialized successfully");

		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(ProductPage), typeof(Pages.ProductPage));
		Routing.RegisterRoute(nameof(StaffPage), typeof(Pages.StaffPage));
		Routing.RegisterRoute(nameof(ShiftPage), typeof(Pages.ShiftPage));
		Routing.RegisterRoute(nameof(PromotionPage), typeof(Pages.PromotionPage));
		Routing.RegisterRoute(nameof(OrderPage), typeof(Pages.OrderPage));
		Routing.RegisterRoute(nameof(RevenuePage), typeof(Pages.RevenuePage));
	}

}

