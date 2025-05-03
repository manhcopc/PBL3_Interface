using PBL3_Interface.Pages;
namespace PBL3_Interface;

public partial class Templates_Manager : ResourceDictionary
{
    public Templates_Manager()
    {
        InitializeComponent();
    }

    private async void OnHomeClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("//MainPage");
    private async void OnProductClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("ProductPage");
    private async void OnStaffClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("StaffPage");
    private async void OnShiftClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("ShiftPage");
    private async void OnPromotionClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PromotionPage");
    private async void OnOrderClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("OrderPage");
    private async void OnRevenueClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("RevenuePage");
}
