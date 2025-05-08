using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class ProductPage : ContentPage
{
    public ProductPage()
    {
        InitializeComponent();
        // Hiển thị sản phẩm mặc định khi trang được tải (Cà phê)
        // ShowProducts("Cà phê");
    }

    // Sự kiện khi người dùng chọn một danh mục
    private void OnCategoryTapped(object sender, EventArgs e)
    {
        // Lấy danh mục được chọn
        var label = sender as Label;
        if (label == null) return;

        // Đổi màu nền để đánh dấu danh mục được chọn
        CategoryCoffee.BackgroundColor = label.Text == "Cà phê" ? Colors.White : Colors.Transparent;
        CategoryMilkTea.BackgroundColor = label.Text == "Trà sữa" ? Colors.White : Colors.Transparent;

        // Hiển thị sản phẩm tương ứng
        // ShowProducts(label.Text);
    }


    // Sự kiện khi nhấn nút "Tìm"
    private void OnSearchClicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Bạn đã nhấn nút Tìm!", "OK");
    }

    // Sự kiện khi nhấn nút "Thêm sản phẩm"
    private void OnAddProductClicked(object sender, EventArgs e)
    {
        // Hiển thị popup cùng với lớp nền mờ
        PopupOverlay.IsVisible = true;
    }

    // Sự kiện khi nhấn nút "Lưu" trong popup
    private void OnSaveProductClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ProductNameEntry.Text) && !string.IsNullOrWhiteSpace(ProductPriceEntry.Text))
        {
            var newProduct = new Label
            {
                Text = $"{ProductNameEntry.Text} - {ProductPriceEntry.Text} VNĐ",
                FontSize = 16,
                TextColor = Colors.Black
            };
            // ProductList.Children.Add(newProduct);
            PopupOverlay.IsVisible = false;
            ProductNameEntry.Text = string.Empty;
            ProductPriceEntry.Text = string.Empty;
        }
        else
        {
            DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "OK");
        }
    }

    // Sự kiện khi nhấn nút "Hủy" trong popup
    private void OnCancelProductClicked(object sender, EventArgs e)
    {
        // Ẩn popup và lớp nền mờ
        PopupOverlay.IsVisible = false;
        ProductNameEntry.Text = string.Empty;
        ProductPriceEntry.Text = string.Empty;
    }
    private void OnEditProductClicked(object sender, EventArgs e) { }
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