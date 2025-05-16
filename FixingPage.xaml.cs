namespace PBL3_Interface;

public partial class FixingPage : ContentPage
{
    public FixingPage()
    {
        InitializeComponent();

        // viewModel = BindingContext as ProductViewModel;
        this.SizeChanged += (s, e) =>
        {
            double width = this.Width;

            double baseWidth = 1440; // chi?u r?ng chu?n thi?t k?
            double scale = this.Width / baseWidth;

            // Clamp ?? không quá nh? ho?c quá to
            // scale = Math.Max(0.5, Math.Min(scale, 1.5));
            if (Application.Current != null)
            {
                Application.Current.Resources["MenuFontSize"] = 20 * scale;
                Application.Current.Resources["MenuItemPadding"] = new Thickness(8 * scale, 4 * scale);
                Application.Current.Resources["MenuItemMargin"] = new Thickness(10 * scale, 0);
                Application.Current.Resources["NavIconSize"] = 30 * scale;
                Application.Current.Resources["NavBoxSize"] = 60 * scale;
            }
        };
    }

    // Lua chon DANH MUC
    private bool isCoffeeClick = false;
    private bool isTeaClick = false;
    private bool isCakeClick = false;
    // Nhan vao nut DANH MUC Ca Phe
    private async void OnCoffeeButtonClicked(object sender, EventArgs e)
    {
    }
    // Nhan vao nut DANH MUC Tra
    private async void OnTeaButtonClicked(object sender, EventArgs e)
    {

    }
    // Nhan vao nut DANH MUC Banh Ngot
    private async void OnCakeButtonClicked(object sender, EventArgs e)
    {

    }

    // Chon MON
    private void ChooseButtonClicked(object sender, EventArgs e)
    {

    }
    // Them QUANTITY
    private void AddQuantityClicked(object sender, EventArgs e)
    {

    }
    // Giam QUANTITY
    private void DelQuantityClicked(object sender, EventArgs e)
    {

    }
    // XAC NHAN DAT MON
    public void OnOrderButtonClicked(object sender, EventArgs e)
    {

    }

    public void DeleteDetailClicked(object sender, EventArgs e) { }

    //Nút tạo hoá đơn chờ
    public void OnAddQueueClicked(object sender, EventArgs e)
    {
        AddQueue.IsVisible = true;
        SaveQueue.IsVisible = false;
        var frame = new Frame
        {
            HeightRequest = 100,
            BackgroundColor = Colors.LightGray,
            CornerRadius = 10
        };
    }
    //Mở popup thêm ưu đãi
    public void OnAddPromotionClicked(object sender, EventArgs e)
    {
        PopupPromotion.IsVisible = true;
    }
    //Mở popup thêm mô tả và chi tiết sản phẩm
    public void OnDetailProductTapped(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = true;
    }
    //POPUP mở mô tả sản phẩm
    private void OnOverlayTapped(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = false;

    }

    //Thoát popup
    private void OnOutPromotionTapped(object sender, EventArgs e)
    {
        PopupPromotion.IsVisible = false;

    }

    //Thoát popup
    private void OnOpenDetailTapped(object sender, EventArgs e)
    {
        AddQueue.IsVisible = false;
        SaveQueue.IsVisible = true;

    }



}