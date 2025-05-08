using Microsoft.Maui.Controls;

namespace PBL3_Interface;

public partial class Login : ContentPage
{
    private double _lastScale = -1;
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
        double baseHeight = 800;

        // Tính scale mà không dùng Math.Min hoặc Math.Max
        double widthScale = width / baseWidth;
        double heightScale = height / baseHeight;
        double minScale = widthScale < heightScale ? widthScale : heightScale; // Thay Math.Min
        double scale = minScale > 0.5 ? minScale : 0.5; // Thay Math.Max

        // Kiểm tra sự thay đổi scale mà không dùng Math.Abs
        double scaleDiff = scale - _lastScale;
        double absScaleDiff = scaleDiff < 0 ? -scaleDiff : scaleDiff; // Thay Math.Abs

        // Chỉ cập nhật nếu scale thay đổi
        if (absScaleDiff > 0.01) // Ngưỡng thay đổi nhỏ
        {
            Resources["DynamicFontSizeTitle"] = 30 * scale;
            Resources["DynamicFontSizeLarge"] = 20 * scale;
            Resources["DynamicFontSizeMedium"] = 16 * scale;
            Resources["DynamicPadding"] = 8 * scale;
            Resources["DynamicMargin"] = 5 * scale;
            Resources["DynamicSpacing"] = 10 * scale;
            Resources["DynamicButtonSize"] = 40 * scale;
            Resources["DynamicLoginWidth"] = 500 * scale;
            Resources["DynamicLoginHeight"] = 600 * scale;
            Resources["DynamicBorderThickness"] = 1 * scale;

            double cornerRadius = 10 * scale;
            Resources["DynamicCornerRadius"] = new CornerRadius(cornerRadius, cornerRadius, cornerRadius, cornerRadius);

            _lastScale = scale; // Lưu giá trị scale mới
        }
    }
}