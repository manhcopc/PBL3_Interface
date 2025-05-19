namespace PBL3_Interface.Pages;

public partial class AccountCashierPage : ContentPage
{
    private double _lastScale = -1;
    public AccountCashierPage()
    {
        InitializeComponent();
        // Resources["IndexToBooleanConverter"] = new IndexToBooleanConverter();
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

            // DetailPopup.WidthRequest = scale * 500;
            // DetailPopup.HeightRequest = scale * 600;

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
    ///////////////////////
    private void OnRoleClicked(object sender, EventArgs e)
    {
        var label = sender as Label;
        if (label == null) return;

        ChangePasswordOption.BackgroundColor = label.Text == "Đổi mật khẩu" ? Color.FromHex("#C6E2FF") : Color.FromHex("#4B3621");
        InformationOption.BackgroundColor = label.Text == "Thông tin cá nhân" ? Color.FromHex("#C6E2FF") : Color.FromHex("#4B3621");
    }
    private void OnChangePasswordClicked(object Sender, EventArgs e)
    {
        Information.IsVisible = false;
        ChangePassword.IsVisible = true;
    }
    private void OnInformationClicked(object Sender, EventArgs e)
    {
        Information.IsVisible = true;
        ChangePassword.IsVisible = false;
    }
}
