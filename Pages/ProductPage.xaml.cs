using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class ProductPage : ContentPage
{
    private double _lastScale = -1;
    private string _selectedProductName = string.Empty;

    public ProductPage()
    {
        InitializeComponent();
    }

    private void OnCategoryTapped(object sender, EventArgs e)
    {
        if (sender is not Label label) return;

        CategoryCoffee.BackgroundColor = label.Text == "☕ CÀ PHÊ" ? Colors.White : Colors.Transparent;
        CategoryMilkTea.BackgroundColor = label.Text == "🍵 TRÀ" ? Colors.White : Colors.Transparent;

        DisplayAlert("Thông báo", $"Bạn đã chọn danh mục: {label.Text}", "OK");
    }

    private void OnSearchClicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Bạn đã nhấn nút Tìm!", "OK");
    }

    private void OnAddProductClicked(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = true;
    }

    private void OnSaveProductClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ProductNameEntry.Text) && !string.IsNullOrWhiteSpace(ProductPriceEntry.Text))
        {
            DisplayAlert("Thông báo", $"Sản phẩm '{ProductNameEntry.Text}' đã được thêm với giá {ProductPriceEntry.Text} VNĐ!", "OK");

            PopupOverlay.IsVisible = false;
            ProductNameEntry.Text = string.Empty;
            ProductDescriptionEntry.Text = string.Empty;
            ProductPriceEntry.Text = string.Empty;
        }
        else
        {
            DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "OK");
        }
    }

    private void OnCancelProductClicked(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = false;
        ProductNameEntry.Text = string.Empty;
        ProductDescriptionEntry.Text = string.Empty;
        ProductPriceEntry.Text = string.Empty;
    }

    private void OnEditProductClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            _selectedProductName = button.BindingContext as string ?? string.Empty;
            EditProductNameEntry.Text = _selectedProductName;
            EditProductDescriptionEntry.Text = "Thông tin mô tả mẫu";
            EditProductPriceEntry.Text = "100000";

            EditProductPopup.IsVisible = true;
        }
    }

    private void OnSaveEditProductClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(EditProductNameEntry.Text) && !string.IsNullOrWhiteSpace(EditProductPriceEntry.Text))
        {
            DisplayAlert("Thông báo", $"Sản phẩm '{_selectedProductName}' đã được cập nhật thành '{EditProductNameEntry.Text}' với giá {EditProductPriceEntry.Text} VNĐ!", "OK");

            EditProductPopup.IsVisible = false;
            EditProductNameEntry.Text = string.Empty;
            EditProductDescriptionEntry.Text = string.Empty;
            EditProductPriceEntry.Text = string.Empty;

            _selectedProductName = string.Empty; // Reset sản phẩm đang được chỉnh sửa
        }
        else
        {
            DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "OK");
        }
    }

    // Hủy chỉnh sửa sản phẩm
    private void OnCancelEditProductClicked(object sender, EventArgs e)
    {
        EditProductPopup.IsVisible = false;
        EditProductNameEntry.Text = string.Empty;
        EditProductDescriptionEntry.Text = string.Empty;
        EditProductPriceEntry.Text = string.Empty;

        _selectedProductName = string.Empty; // Reset sản phẩm đang được chỉnh sửa
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        double baseWidth = 400;
        double baseHeight = 800;

        double widthScale = width / baseWidth;
        double heightScale = height / baseHeight;
        double scale = widthScale < heightScale ? widthScale : heightScale;

        scale = scale > 0.5 ? scale : 0.5;
        double horizontalScale = (width / baseWidth) > 0.5 ? (width / baseWidth) : 0.5;


        if (_lastScale < 0 || (scale > _lastScale + 0.01 || scale < _lastScale - 0.01))
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

            AddProductPopup.WidthRequest = scale * 500; // Chiều rộng linh hoạt
            AddProductPopup.HeightRequest = scale * 600; // Chiều cao linh hoạt

            EditProductPopupFrame.WidthRequest = scale * 500;
            EditProductPopupFrame.HeightRequest = scale * 600;

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