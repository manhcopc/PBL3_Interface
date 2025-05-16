using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class OrderPage : ContentPage
{
    private double _lastScale = -1;
    private Frame? _selectedShift;
    /// ///////////////
    private ImageButton? _flyoutBarButton; // Tham chiếu đến ImageButton
    private Grid? _flyoutBarPopup; // Tham chiếu đến FlyoutBarPopup
    private Grid? _popupContentGrid; // Tham chiếu đến nội dung popup
    private Button? _logoutButton; // Tham chiếu đến nút Đăng xuất

    public OrderPage()
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

    // Sự kiện khi nhấn nút "Lọc"
    private void FilterButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Lọc đã được nhấn!", "OK");
    }

    private void ViewOrderDetail_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Thông báo", "Nút Xem chi tiết đã được nhấn!", "OK");
    }
    private void OnShiftClicked(object sender, EventArgs e)
    {

        _selectedShift = sender as Frame;
        FirstShift.BackgroundColor = Color.FromHex("#FFEFD5");
        SecondShift.BackgroundColor = Color.FromHex("#FFEFD5");
        ThirdShift.BackgroundColor = Color.FromHex("#FFEFD5");
        // var frame = sender as Frame;
        if (_selectedShift == FirstShift)
        {
            FirstShift.BackgroundColor = Color.FromHex("#C6E2FF");
        }
        if (_selectedShift == SecondShift)
        {
            SecondShift.BackgroundColor = Color.FromHex("#C6E2FF");
        }
        if (_selectedShift == ThirdShift)
        {
            ThirdShift.BackgroundColor = Color.FromHex("#C6E2FF");
        }
    }



    // Sự kiện khi nhấn nút "Lọc"
    private void OnFilterClicked(object sender, EventArgs e)
    {
        FilterPopupOverlay.IsVisible = true;
    }


    // Sự kiện khi nhấn nút "Áp dụng" trong popup lọc
    private void OnApplyFilterClicked(object sender, EventArgs e)
    {
        var selectedDate = FilterDatePicker.Date.ToString("dd/MM/yyyy");
        // Cập nhật ngày trên giao diện (ví dụ: Label trong Frame header)
        var dateLabel = this.FindByName<Label>("dateLabel"); // Giả định có Label tên "dateLabel"
        if (dateLabel != null)
        {
            dateLabel.Text = selectedDate;
        }
        FilterPopupOverlay.IsVisible = false;
    }

    // Sự kiện khi nhấn nút "Hủy" trong popup lọc
    private void OnCancelFilterClicked(object sender, EventArgs e)
    {
        FilterPopupOverlay.IsVisible = false;
    }

    // Sự kiện khi nhấn nút "Xem chi tiết"
    private void OnViewDetailClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            var grid = button.Parent as Grid;
            if (grid != null)
            {

                DetailPopupOverlay.IsVisible = true;

            }
        }
    }

    // Sự kiện khi nhấn nút "Đóng" trong popup chi tiết
    private void OnCloseDetailClicked(object sender, EventArgs e)
    {
        DetailPopupOverlay.IsVisible = false;
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

            // FilterPopupOverlay.WidthRequest = scale * 500; // Chiều rộng linh hoạt
            // FilterPopupOverlay.HeightRequest = scale * 600; // Chiều cao linh hoạt

            DetailPopup.WidthRequest = scale * 500;
            DetailPopup.HeightRequest = scale * 600;

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