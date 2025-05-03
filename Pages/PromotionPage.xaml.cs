using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PBL3_Interface.Pages;

public partial class PromotionPage : ContentPage
{
    public PromotionPage()
    {
        InitializeComponent();
        BindingContext = new PromotionPageViewModel();
    }
}

public class PromotionPageViewModel : BindableObject
{
    // Dữ liệu nhập từ form "Thêm ưu đãi"
    private string _newPromotionCode;
    private string _newPromotionName;
    private string _newPromotionDescription;
    private string _newPromotionValue;

    public string NewPromotionCode
    {
        get => _newPromotionCode;
        set { _newPromotionCode = value; OnPropertyChanged(); }
    }

    public string NewPromotionName
    {
        get => _newPromotionName;
        set { _newPromotionName = value; OnPropertyChanged(); }
    }

    public string NewPromotionDescription
    {
        get => _newPromotionDescription;
        set { _newPromotionDescription = value; OnPropertyChanged(); }
    }

    public string NewPromotionValue
    {
        get => _newPromotionValue;
        set { _newPromotionValue = value; OnPropertyChanged(); }
    }

    // Dữ liệu danh sách ưu đãi
    public ObservableCollection<Promotion> CompletedPromotions { get; set; }
    public ObservableCollection<Promotion> OngoingPromotions { get; set; }
    public ObservableCollection<Promotion> UpcomingPromotions { get; set; }

    // Dữ liệu chi tiết ưu đãi (cho phép chỉnh sửa)
    private string _selectedPromotionCode;
    private string _selectedPromotionName;
    private string _selectedPromotionDescription;
    private string _selectedPromotionValue;
    private string _selectedReleaseValue = "15.000";
    private string _selectedReleaseDate = "15/05/2025 - 30/05/2025";
    private bool _isDetailVisible;

    public string SelectedPromotionCode
    {
        get => _selectedPromotionCode;
        set { _selectedPromotionCode = value; OnPropertyChanged(); }
    }

    public string SelectedPromotionName
    {
        get => _selectedPromotionName;
        set { _selectedPromotionName = value; OnPropertyChanged(); }
    }

    public string SelectedPromotionDescription
    {
        get => _selectedPromotionDescription;
        set { _selectedPromotionDescription = value; OnPropertyChanged(); }
    }

    public string SelectedPromotionValue
    {
        get => _selectedPromotionValue;
        set { _selectedPromotionValue = value; OnPropertyChanged(); }
    }

    public string SelectedReleaseValue
    {
        get => _selectedReleaseValue;
        set { _selectedReleaseValue = value; OnPropertyChanged(); }
    }

    public string SelectedReleaseDate
    {
        get => _selectedReleaseDate;
        set { _selectedReleaseDate = value; OnPropertyChanged(); }
    }

    public bool IsDetailVisible
    {
        get => _isDetailVisible;
        set { _isDetailVisible = value; OnPropertyChanged(); }
    }

    // Command
    public ICommand AddPromotionCommand { get; }
    public ICommand PromotionSelectedCommand { get; }
    public ICommand SavePromotionCommand { get; }
    public ICommand DeletePromotionCommand { get; }

    public PromotionPageViewModel()
    {
        // Khởi tạo giá trị mặc định
        NewPromotionCode = "";
        NewPromotionName = "";
        NewPromotionDescription = "";
        NewPromotionValue = "";

        // Khởi tạo danh sách ưu đãi
        CompletedPromotions = new ObservableCollection<Promotion>
        {
            new Promotion { Code = "ƯD001", Name = "Ưu đãi cũ", Value = "5%", DateRange = "01/05/2025 - 10/05/2025" }
        };
        OngoingPromotions = new ObservableCollection<Promotion>
        {
            new Promotion { Code = "ƯD002", Name = "Ưu đãi mùa hè", Value = "10%", DateRange = "15/05/2025 - 25/05/2025" }
        };
        UpcomingPromotions = new ObservableCollection<Promotion>
        {
            new Promotion { Code = "ƯD003", Name = "Ưu đãi mới", Value = "15%", DateRange = "01/06/2025 - 10/06/2025" }
        };

        // Command thêm ưu đãi
        AddPromotionCommand = new Command(() =>
        {
            if (!string.IsNullOrWhiteSpace(NewPromotionCode) && !string.IsNullOrWhiteSpace(NewPromotionName) &&
                !string.IsNullOrWhiteSpace(NewPromotionDescription) && !string.IsNullOrWhiteSpace(NewPromotionValue))
            {
                var newPromotion = new Promotion
                {
                    Code = NewPromotionCode,
                    Name = NewPromotionName,
                    Description = NewPromotionDescription,
                    Value = NewPromotionValue,
                    DateRange = "15/05/2025 - 30/05/2025" // Giả lập ngày
                };

                // Thêm vào danh sách "Sắp tới" (có thể điều chỉnh logic dựa trên ngày)
                UpcomingPromotions.Add(newPromotion);

                // Reset form
                NewPromotionCode = "";
                NewPromotionName = "";
                NewPromotionDescription = "";
                NewPromotionValue = "";
            }
        });

        // Command chọn ưu đãi
        PromotionSelectedCommand = new Command<Promotion>(selectedPromotion =>
        {
            if (selectedPromotion != null)
            {
                SelectedPromotionCode = selectedPromotion.Code;
                SelectedPromotionName = selectedPromotion.Name;
                SelectedPromotionDescription = selectedPromotion.Description;
                SelectedPromotionValue = selectedPromotion.Value;
                SelectedReleaseValue = "15.000"; // Giả lập
                SelectedReleaseDate = "15/05/2025 - 30/05/2025"; // Giả lập
                IsDetailVisible = true;
            }
        });

        // Command lưu ưu đãi
        SavePromotionCommand = new Command(() =>
        {
            // Cập nhật dữ liệu trong danh sách (giả lập)
            var selectedPromo = CompletedPromotions.FirstOrDefault(p => p.Code == SelectedPromotionCode) ??
                               OngoingPromotions.FirstOrDefault(p => p.Code == SelectedPromotionCode) ??
                               UpcomingPromotions.FirstOrDefault(p => p.Code == SelectedPromotionCode);
            if (selectedPromo != null)
            {
                selectedPromo.Name = SelectedPromotionName;
                selectedPromo.Description = SelectedPromotionDescription;
                selectedPromo.Value = SelectedPromotionValue;
                Application.Current.MainPage.DisplayAlert("Thông báo", "Đã cập nhật thành công!", "OK");
            }
        });

        // Command xóa ưu đãi
        DeletePromotionCommand = new Command(() =>
        {
            var selectedPromo = CompletedPromotions.FirstOrDefault(p => p.Code == SelectedPromotionCode) ??
                               OngoingPromotions.FirstOrDefault(p => p.Code == SelectedPromotionCode) ??
                               UpcomingPromotions.FirstOrDefault(p => p.Code == SelectedPromotionCode);
            if (selectedPromo != null)
            {
                if (CompletedPromotions.Contains(selectedPromo))
                    CompletedPromotions.Remove(selectedPromo);
                else if (OngoingPromotions.Contains(selectedPromo))
                    OngoingPromotions.Remove(selectedPromo);
                else if (UpcomingPromotions.Contains(selectedPromo))
                    UpcomingPromotions.Remove(selectedPromo);

                // Reset chi tiết
                SelectedPromotionCode = "";
                SelectedPromotionName = "";
                SelectedPromotionDescription = "";
                SelectedPromotionValue = "";
                SelectedReleaseValue = "";
                SelectedReleaseDate = "";
                IsDetailVisible = false;
                Application.Current.MainPage.DisplayAlert("Thông báo", "Đã xóa thành công!", "OK");
            }
        });

        // Ẩn chi tiết ban đầu
        IsDetailVisible = false;
    }
}

// Model cho Promotion
public class Promotion
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Value { get; set; }
    public string DateRange { get; set; }
}