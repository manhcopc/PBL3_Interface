using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class PromotionPage : ContentPage
{
    private double _lastScale = -1;
    /// ///////////////
    private ImageButton? _flyoutBarButton; // Tham chiếu đến ImageButton
    private Grid? _flyoutBarPopup; // Tham chiếu đến FlyoutBarPopup
    private Grid? _popupContentGrid; // Tham chiếu đến nội dung popup
    private Button? _logoutButton; // Tham chiếu đến nút Đăng xuất

    public PromotionPage()
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
