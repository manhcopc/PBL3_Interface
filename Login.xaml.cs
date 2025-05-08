using Microsoft.Maui.Controls;

namespace PBL3_Interface;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        // Logic đăng nhập
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        double baseWidth = 400;
        double scale = Math.Max(0.5, Math.Min(width, height) / baseWidth);

        // Update dynamic resources
        Resources["DynamicFontSizeTitle"] = 15 * scale;
        Resources["DynamicFontSizeLarge"] = 12 * scale;
        Resources["DynamicFontSizeMedium"] = 10 * scale;
        Resources["DynamicFontSizeSmall"] = 8 * scale;
        Resources["DynamicPadding"] = 4 * scale;
        Resources["DynamicMargin_Main"] = 5 * scale;
        Resources["DynamicMargin"] = 2.5 * scale;
        Resources["DynamicMarginPopup"] = 50 * scale;
        Resources["DynamicCornerRadius"] = 5 * scale;
        Resources["DynamicCornerRadius_Inside"] = 10 * scale;
        Resources["DynamicCornerRadius_Outside"] = 20 * scale;
        Resources["DynamicSpacing"] = 5 * scale;
        Resources["DynamicButtonHeight"] = 20 * scale;
        Resources["DynamicButtonWidth"] = 50 * scale;
        Resources["DynamicLoginWidth"] = 150 * scale;
        Resources["DynamicLoginHeight"] = 200 * scale;
    }
}