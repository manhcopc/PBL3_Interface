using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class ProductPage : ContentPage
{

    private double _lastScale = -1;
    private string _selectedProductName = string.Empty;

    /// ///////////////
    private ImageButton? _flyoutBarButton; // Tham chiếu đến ImageButton
    private Grid? _flyoutBarPopup; // Tham chiếu đến FlyoutBarPopup
    private Grid? _popupContentGrid; // Tham chiếu đến nội dung popup
    private Button? _logoutButton; // Tham chiếu đến nút Đăng xuất

    public ProductPage()
    {
        InitializeComponent();

        // Lấy tham chiếu đến FlyoutBarPopup từ ControlTemplate
        _flyoutBarPopup = (Grid)GetTemplateChild("FlyoutBarPopup");

        // Lấy tham chiếu đến nội dung popup (để kiểm tra click ra ngoài)
        _popupContentGrid = (Grid)GetTemplateChild("PopupContentGrid");

        // Lấy tham chiếu đến ImageButton từ ControlTemplate
        _flyoutBarButton = (ImageButton)GetTemplateChild("FlyoutBarButton");

        // Lấy tham chiếu đến nút Đăng xuất từ ControlTemplate
        _logoutButton = (Button)GetTemplateChild("LogoutButton");

        // Gắn sự kiện Clicked động
        if (_flyoutBarButton != null)
        {
            _flyoutBarButton.Clicked += OnFlyoutBarClicked;
        }

        // Gắn sự kiện Clicked cho nút Đăng xuất
        if (_logoutButton != null)
        {
            _logoutButton.Clicked += OnLogoutClicked;
        }

        // Gắn sự kiện TapGestureRecognizer cho FlyoutBarPopup để xử lý click ra ngoài
        if (_flyoutBarPopup != null)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnOutsideTapped;
            _flyoutBarPopup.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }

    private void OnFlyoutBarClicked(object sender, EventArgs e)
    {
        if (_flyoutBarPopup != null)
        {
            _flyoutBarPopup.IsVisible = !_flyoutBarPopup.IsVisible; // Hiển thị/ẩn FlyoutBarPopup
        }
    }

    private void OnOutsideTapped(object sender, EventArgs e)
    {
        if (_flyoutBarPopup != null && _popupContentGrid != null)
        {
            var grid = sender as Grid;
            var position = (e as TappedEventArgs)?.GetPosition(grid);
            if (position.HasValue)
            {
                var contentPosition = _popupContentGrid.Bounds.Location;
                var contentWidth = _popupContentGrid.Width;
                var contentHeight = _popupContentGrid.Height;
                if (position.Value.X < contentPosition.X || position.Value.X > contentPosition.X + contentWidth ||
                    position.Value.Y < contentPosition.Y || position.Value.Y > contentPosition.Y + contentHeight)
                {
                    _flyoutBarPopup.IsVisible = false; // Đóng popup khi click ra ngoài nội dung
                }
            }
        }
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        if (_flyoutBarPopup != null)
        {
            _flyoutBarPopup.IsVisible = false; // Ẩn FlyoutBarPopup
            // Điều hướng về trang đăng nhập
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
    /////////////
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

            // AddProductPopup.WidthRequest = scale * 500; // Chiều rộng linh hoạt
            // AddProductPopup.HeightRequest = scale * 600; // Chiều cao linh hoạt

            // EditProductPopupFrame.WidthRequest = scale * 500;
            // EditProductPopupFrame.HeightRequest = scale * 600;

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

    private bool _isProductGroupOptionsVisible = false; // Biến trạng thái cho tùy chọn nhóm sản phẩm trong popup
    //Popup them san pham
    private void OnAddProductClicked(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = true;
    }
    private void OnSaveProductClicked(object sender, EventArgs e)
    {

        PopupOverlay.IsVisible = false;

    }

    private void OnCancelProductClicked(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = false;

    }



    //Popup edit san pharm
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
        string name = EditProductNameEntry.Text?.Trim();
        string description = EditProductDescriptionEntry.Text?.Trim();
        string priceText = EditProductPriceEntry.Text?.Trim();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceText))
        {
            DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ tên và giá sản phẩm.", "OK");
            return;
        }

        if (!decimal.TryParse(priceText, out decimal price))
        {
            DisplayAlert("Lỗi", "Giá sản phẩm không hợp lệ.", "OK");
            return;
        }

        SaveEditedProduct(name, description, price);

        EditProductPopup.IsVisible = false;
    }

    private void OnCancelEditProductClicked(object sender, EventArgs e)
    {
        EditProductPopup.IsVisible = false;
    }

    private void SaveEditedProduct(string name, string description, decimal price)
    {
        Console.WriteLine($"Đã lưu sản phẩm: {name}, {description}, Giá: {price}");
    }

    public void ShowEditProductPopup(string name, string description, decimal price, string group)
    {
        EditProductNameEntry.Text = name;
        EditProductDescriptionEntry.Text = description;
        EditProductPriceEntry.Text = price.ToString();
        EditProductGroupLabel.Text = group;

        EditProductPopup.IsVisible = true;
    }
    //Popup nhom san pham va cac thao tac trong do
    private void OnProductGroupLabelTapped(object sender, EventArgs e)
    {
        _isProductGroupOptionsVisible = true;
        ProductGroupOptions.IsVisible = _isProductGroupOptionsVisible;
    }

    private void OnCoffeeOptionSelected(object sender, EventArgs e)
    {
        ProductGroupLabel.Text = "Cà phê";
        _isProductGroupOptionsVisible = false;
        ProductGroupOptions.IsVisible = _isProductGroupOptionsVisible;
    }

    private void OnTeaOptionSelected(object sender, EventArgs e)
    {
        ProductGroupLabel.Text = "Trà";
        _isProductGroupOptionsVisible = false;
        ProductGroupOptions.IsVisible = _isProductGroupOptionsVisible;
    }

    private void OnPastryOptionSelected(object sender, EventArgs e)
    {
        ProductGroupLabel.Text = "Bánh ngọt";
        _isProductGroupOptionsVisible = false;
        ProductGroupOptions.IsVisible = _isProductGroupOptionsVisible;
    }
    private void OnCoffeeOptionClicked(object sender, EventArgs e) { }
    private void OnTeaOptionClicked(object sender, EventArgs e) { }
    private void OnPastryOptionClicked(object sender, EventArgs e) { }
}