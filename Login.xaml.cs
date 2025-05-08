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


        base.OnSizeAllocated(width, height);

        double baseWidth = 400; // Chiều rộng cơ bản
        double baseHeight = 800; // Chiều cao cơ bản
        double scale = Math.Max(0.5, Math.Min(width / baseWidth, height / baseHeight)); // Tỷ lệ tổng quát

        Resources["DynamicFontSizeTitle"] = 30 * scale;
        Resources["DynamicFontSizeLarge"] = 20 * scale;
        Resources["DynamicFontSizeMedium"] = 16 * scale;
        Resources["DynamicFontSizeSmall"] = 12 * scale;
        Resources["DynamicPadding"] = 8 * scale;
        Resources["DynamicMargin_Main"] = 10 * scale;
        Resources["DynamicMargin"] = 5 * scale;
        Resources["DynamicMarginPopup"] = 200 * scale;
        Resources["DynamicSpacing"] = 10 * scale;
        Resources["DynamicButtonHeight"] = 40 * scale;
        Resources["DynamicButtonWidth"] = 100 * scale;
        Resources["DynamicLoginWidth"] = 500 * scale;
        Resources["DynamicLoginHeight"] = 600 * scale;
        Resources["DynamicBorderThickness"] = 1 * scale; // Điều chỉnh độ dày viền
        Resources["DynamicBorderCornerRadius"] = 10 * scale; // Điều chỉnh bán kính góc

        double cornerRadius = 10 * scale;
        Resources["DynamicCornerRadius"] = new CornerRadius(cornerRadius, cornerRadius, cornerRadius, cornerRadius);
    }
}