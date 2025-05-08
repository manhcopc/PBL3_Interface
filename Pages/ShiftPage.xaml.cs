using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class ShiftPage : ContentPage
{
    private double _lastScale = -1;
    public ShiftPage()
    {
        InitializeComponent();
    }

    // Sự kiện khi chạm vào tiêu đề Ca 1
    private void ToggleShift1_Tapped(object sender, EventArgs e)
    {
        Shift1Details.IsVisible = !Shift1Details.IsVisible;
    }

    // Sự kiện khi chạm vào tiêu đề Ca 2
    private void ToggleShift2_Tapped(object sender, EventArgs e)
    {
        Shift2Details.IsVisible = !Shift2Details.IsVisible;
    }

    // Sự kiện khi chạm vào tiêu đề Ca 3
    private void ToggleShift3_Tapped(object sender, EventArgs e)
    {
        Shift3Details.IsVisible = !Shift3Details.IsVisible;
    }

    // Sự kiện khi nhấn nút "Thêm nhân viên" cho Ca 1
    private void AddEmployeeToShift1_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Thêm nhân viên cho Ca 1 đã được nhấn!", "OK");
    }

    // Sự kiện khi nhấn nút "Thêm nhân viên" cho Ca 2
    private void AddEmployeeToShift2_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Thêm nhân viên cho Ca 2 đã được nhấn!", "OK");
    }

    // Sự kiện khi nhấn nút "Thêm nhân viên" cho Ca 3
    private void AddEmployeeToShift3_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Thêm nhân viên cho Ca 3 đã được nhấn!", "OK");
    }

    // Sự kiện khi nhấn nút "Xóa" nhân viên
    private void RemoveEmployee_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Xóa nhân viên đã được nhấn!", "OK");
    }

    // Sự kiện khi chọn ngày
    private void SelectDate_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;

        // Reset màu sắc của tất cả nút ngày
        DateButton1.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton2.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton3.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton4.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton5.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton6.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton7.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton8.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton9.BackgroundColor = Color.FromHex("#CCCCCC");
        DateButton10.BackgroundColor = Color.FromHex("#CCCCCC");

        // Cập nhật màu nền cho nút ngày được chọn
        button.BackgroundColor = Color.FromHex("#FF9999");

        // Cập nhật label ngày làm
        SelectedDateLabel.Text = $"Ngày làm: {button.Text}/2025";
    }

    // Sự kiện khi nhấn nút "Thêm ngày làm"
    private void AddDate_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Thêm ngày làm đã được nhấn!", "OK");
    }
    private void OnCancelEditShiftClicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Bạn đã nhấn nút Huỷ!", "OK");
    }
    private void OnSaveEditShiftClicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Bạn đã nhấn nút lưu!", "OK");
    }
    private void OnSaveShiftClicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Bạn đã nhấn nút lưu!", "OK");
    }
    private void OnCancelShiftClicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Bạn đã nhấn nút Huỷ!", "OK");
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        double baseWidth = 400;
        double baseHeight = 800;

        // Tính scale mà không dùng Math.Min hoặc Math.Max
        double widthScale = width / baseWidth;
        double heightScale = height / baseHeight;
        double minScale = widthScale < heightScale ? widthScale : heightScale;
        double scale = minScale > 0.5 ? minScale : 0.5;

        // Kiểm tra sự thay đổi scale mà không dùng Math.Abs
        double scaleDiff = scale - _lastScale;
        double absScaleDiff = scaleDiff < 0 ? -scaleDiff : scaleDiff;
        double horizontalScale = (width / baseWidth) > 0.5 ? (width / baseWidth) : 0.5;

        if (absScaleDiff > 0.01)
        {
            Resources["DynamicFontSizeTitle"] = 30 * scale;
            Resources["DynamicFontSizeLarge"] = 20 * scale;
            Resources["DynamicFontSizeMedium"] = 16 * scale;
            Resources["DynamicFontSizeSmall"] = 12 * scale;
            Resources["DynamicPadding"] = 8 * scale;
            Resources["DynamicMargin"] = 5 * scale;
            Resources["DynamicSpacing"] = 10 * scale;
            Resources["DynamicButtonSize"] = 40 * scale;
            Resources["DynamicBorderThickness"] = 1 * scale;

            double cornerRadius = 10 * scale;
            Resources["DynamicCornerRadius"] = new CornerRadius(cornerRadius);

            EditShiftPopupOverlay.WidthRequest = scale * 500; // Chiều rộng linh hoạt
            EditShiftPopupOverlay.HeightRequest = scale * 600; // Chiều cao linh hoạt



            Resources["NaviHeightRequest"] = 60 * scale;
            Resources["TabMenuHeightRequest"] = 25 * scale;
            Resources["TabMenuWidthRequest"] = 25 * scale;
            Resources["NaviTextFontSize"] = 25 * scale;
            Resources["NaviItemSpacing"] = 2 * horizontalScale;
            Resources["NaviMargin"] = 2 * horizontalScale; // Điều chỉnh Margin theo chiều ngang
            Resources["NaviPadding"] = 5 * horizontalScale;

            _lastScale = scale;
        }
    }
}