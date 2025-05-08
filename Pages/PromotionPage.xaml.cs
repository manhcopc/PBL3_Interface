using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class PromotionPage : ContentPage
{
    public PromotionPage()
    {
        InitializeComponent();

    }

    // Sự kiện khi nhấn nút "Thêm" (chỉ hiển thị thông báo, không lưu dữ liệu)
    private void AddButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Thêm đã được nhấn (không lưu dữ liệu)!", "OK");
    }

    // Sự kiện khi nhấn các nút bộ lọc (chỉ thay đổi màu sắc)
    private void FilterButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;

        // Reset màu sắc
        CompletedFilterButton.BackgroundColor = Colors.LightGray;
        OngoingFilterButton.BackgroundColor = Colors.LightGray;
        UpcomingFilterButton.BackgroundColor = Colors.LightGray;

        // Đặt màu cho nút được chọn
        button.BackgroundColor = Color.FromHex("#DDA0DD");
    }

    // Sự kiện khi tap vào một Frame ưu đãi


    // Sự kiện khi nhấn nút "Lưu" (chỉ hiển thị thông báo)
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Lưu đã được nhấn (không cập nhật dữ liệu)!", "OK");
    }

    // Sự kiện khi nhấn nút "Xóa" (chỉ hiển thị thông báo và reset)
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Xóa đã được nhấn (không xóa dữ liệu)!", "OK");
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        // Đảm bảo scale không quá nhỏ hoặc âm
        double baseWidth = 400; // Giá trị chuẩn
        double scale = Math.Max(0.5, Math.Min(width, height) / baseWidth); // Giới hạn scale từ 0.5

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
