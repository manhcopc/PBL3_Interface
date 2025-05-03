using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
namespace PBL3_Interface.Pages;

public partial class ShiftPage : ContentPage
{
    public ShiftPage()
    {
        InitializeComponent();
        BindingContext = new ShiftPageViewModel();
    }
}

public class ShiftPageViewModel : BindableObject
{
    // Trạng thái ẩn/hiện cho các ca
    private bool _isShift1Visible;
    private bool _isShift2Visible;
    private bool _isShift3Visible;

    // Danh sách nhân viên theo vai trò trong từng ca
    public ObservableCollection<Employee> Shift1Cashiers { get; set; }
    public ObservableCollection<Employee> Shift1Baristas { get; set; }
    public ObservableCollection<Employee> Shift1Waiters { get; set; }
    public ObservableCollection<Employee> Shift2Cashiers { get; set; }
    public ObservableCollection<Employee> Shift2Baristas { get; set; }
    public ObservableCollection<Employee> Shift2Waiters { get; set; }
    public ObservableCollection<Employee> Shift3Cashiers { get; set; }
    public ObservableCollection<Employee> Shift3Baristas { get; set; }
    public ObservableCollection<Employee> Shift3Waiters { get; set; }

    // Danh sách ngày
    private ObservableCollection<string> _dates;
    public ObservableCollection<string> Dates
    {
        get => _dates;
        set { _dates = value; OnPropertyChanged(); }
    }

    // Màu nền cho các nút ngày
    private Color _dateButtonBackground1 = Color.FromHex("#FF9999");
    private Color _dateButtonBackground2 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground3 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground4 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground5 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground6 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground7 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground8 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground9 = Color.FromHex("#CCCCCC");
    private Color _dateButtonBackground10 = Color.FromHex("#CCCCCC");

    public Color DateButtonBackground1
    {
        get => _dateButtonBackground1;
        set { _dateButtonBackground1 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground2
    {
        get => _dateButtonBackground2;
        set { _dateButtonBackground2 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground3
    {
        get => _dateButtonBackground3;
        set { _dateButtonBackground3 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground4
    {
        get => _dateButtonBackground4;
        set { _dateButtonBackground4 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground5
    {
        get => _dateButtonBackground5;
        set { _dateButtonBackground5 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground6
    {
        get => _dateButtonBackground6;
        set { _dateButtonBackground6 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground7
    {
        get => _dateButtonBackground7;
        set { _dateButtonBackground7 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground8
    {
        get => _dateButtonBackground8;
        set { _dateButtonBackground8 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground9
    {
        get => _dateButtonBackground9;
        set { _dateButtonBackground9 = value; OnPropertyChanged(); }
    }
    public Color DateButtonBackground10
    {
        get => _dateButtonBackground10;
        set { _dateButtonBackground10 = value; OnPropertyChanged(); }
    }

    // Ngày được chọn
    private string _selectedDate;
    public string SelectedDate
    {
        get => _selectedDate;
        set { _selectedDate = value; OnPropertyChanged(); }
    }

    // Thống kê
    public int TotalEmployees => Shift1Cashiers.Count + Shift1Baristas.Count + Shift1Waiters.Count;
    public int TotalEmployeesShift2 => Shift2Cashiers.Count + Shift2Baristas.Count + Shift2Waiters.Count;
    public int TotalEmployeesShift3 => Shift3Cashiers.Count + Shift3Baristas.Count + Shift3Waiters.Count;

    public int Shift1CashierCount => Shift1Cashiers.Count;
    public int Shift1BaristaCount => Shift1Baristas.Count;
    public int Shift1WaiterCount => Shift1Waiters.Count;
    public int Shift2CashierCount => Shift2Cashiers.Count;
    public int Shift2BaristaCount => Shift2Baristas.Count;
    public int Shift2WaiterCount => Shift2Waiters.Count;
    public int Shift3CashierCount => Shift3Cashiers.Count;
    public int Shift3BaristaCount => Shift3Baristas.Count;
    public int Shift3WaiterCount => Shift3Waiters.Count;

    // Thuộc tính cho trạng thái ẩn/hiện các ca
    public bool IsShift1Visible
    {
        get => _isShift1Visible;
        set { _isShift1Visible = value; OnPropertyChanged(); }
    }

    public bool IsShift2Visible
    {
        get => _isShift2Visible;
        set { _isShift2Visible = value; OnPropertyChanged(); }
    }

    public bool IsShift3Visible
    {
        get => _isShift3Visible;
        set { _isShift3Visible = value; OnPropertyChanged(); }
    }

    // Commands
    public ICommand ToggleShift1Command { get; }
    public ICommand ToggleShift2Command { get; }
    public ICommand ToggleShift3Command { get; }
    public ICommand SelectDateCommand { get; }
    public ICommand AddDateCommand { get; }
    public ICommand AddEmployeeToShift1Command { get; }
    public ICommand AddEmployeeToShift2Command { get; }
    public ICommand AddEmployeeToShift3Command { get; }
    public ICommand RemoveShift1CashierCommand { get; }
    public ICommand RemoveShift1BaristaCommand { get; }
    public ICommand RemoveShift1WaiterCommand { get; }
    public ICommand RemoveShift2CashierCommand { get; }
    public ICommand RemoveShift2BaristaCommand { get; }
    public ICommand RemoveShift2WaiterCommand { get; }
    public ICommand RemoveShift3CashierCommand { get; }
    public ICommand RemoveShift3BaristaCommand { get; }
    public ICommand RemoveShift3WaiterCommand { get; }

    public ShiftPageViewModel()
    {
        // Khởi tạo danh sách ngày
        Dates = new ObservableCollection<string>
        {
            "01/04/2025", "02/04/2025", "03/04/2025", "04/04/2025", "05/04/2025",
            "06/04/2025", "07/04/2025", "08/04/2025", "09/04/2025", "10/04/2025"
        };

        // Khởi tạo danh sách nhân viên
        Shift1Cashiers = new ObservableCollection<Employee>();
        Shift1Baristas = new ObservableCollection<Employee>();
        Shift1Waiters = new ObservableCollection<Employee>();
        Shift2Cashiers = new ObservableCollection<Employee>();
        Shift2Baristas = new ObservableCollection<Employee>();
        Shift2Waiters = new ObservableCollection<Employee>();
        Shift3Cashiers = new ObservableCollection<Employee>();
        Shift3Baristas = new ObservableCollection<Employee>();
        Shift3Waiters = new ObservableCollection<Employee>();

        // Khởi tạo trạng thái ẩn/hiện
        IsShift1Visible = false;
        IsShift2Visible = false;
        IsShift3Visible = false;

        // Khởi tạo ngày mặc định
        SelectedDate = "01/04/2025";
        UpdateDataForDate(SelectedDate);

        // Khởi tạo Command cho các ca
        ToggleShift1Command = new Command(() =>
        {
            IsShift1Visible = !IsShift1Visible;
            IsShift2Visible = false;
            IsShift3Visible = false;
        });

        ToggleShift2Command = new Command(() =>
        {
            IsShift2Visible = !IsShift2Visible;
            IsShift1Visible = false;
            IsShift3Visible = false;
        });

        ToggleShift3Command = new Command(() =>
        {
            IsShift3Visible = !IsShift3Visible;
            IsShift1Visible = false;
            IsShift2Visible = false;
        });

        // Command chọn ngày
        SelectDateCommand = new Command<string>(date =>
        {
            SelectedDate = date;
            // Reset màu nền của tất cả nút ngày
            DateButtonBackground1 = Color.FromHex("#CCCCCC");
            DateButtonBackground2 = Color.FromHex("#CCCCCC");
            DateButtonBackground3 = Color.FromHex("#CCCCCC");
            DateButtonBackground4 = Color.FromHex("#CCCCCC");
            DateButtonBackground5 = Color.FromHex("#CCCCCC");
            DateButtonBackground6 = Color.FromHex("#CCCCCC");
            DateButtonBackground7 = Color.FromHex("#CCCCCC");
            DateButtonBackground8 = Color.FromHex("#CCCCCC");
            DateButtonBackground9 = Color.FromHex("#CCCCCC");
            DateButtonBackground10 = Color.FromHex("#CCCCCC");

            // Cập nhật màu nền cho ngày được chọn
            switch (date)
            {
                case "01/04/2025":
                    DateButtonBackground1 = Color.FromHex("#FF9999");
                    break;
                case "02/04/2025":
                    DateButtonBackground2 = Color.FromHex("#FF9999");
                    break;
                case "03/04/2025":
                    DateButtonBackground3 = Color.FromHex("#FF9999");
                    break;
                case "04/04/2025":
                    DateButtonBackground4 = Color.FromHex("#FF9999");
                    break;
                case "05/04/2025":
                    DateButtonBackground5 = Color.FromHex("#FF9999");
                    break;
                case "06/04/2025":
                    DateButtonBackground6 = Color.FromHex("#FF9999");
                    break;
                case "07/04/2025":
                    DateButtonBackground7 = Color.FromHex("#FF9999");
                    break;
                case "08/04/2025":
                    DateButtonBackground8 = Color.FromHex("#FF9999");
                    break;
                case "09/04/2025":
                    DateButtonBackground9 = Color.FromHex("#FF9999");
                    break;
                case "10/04/2025":
                    DateButtonBackground10 = Color.FromHex("#FF9999");
                    break;
            }

            // Cập nhật dữ liệu theo ngày
            UpdateDataForDate(date);
        });

        // Command thêm ngày
        AddDateCommand = new Command(() =>
        {
            // Thêm ngày mới (giả lập: thêm ngày tiếp theo)
            var lastDate = Dates.LastOrDefault();
            if (lastDate != null)
            {
                var dateParts = lastDate.Split('/');
                if (int.TryParse(dateParts[0], out int day) && int.TryParse(dateParts[1], out int month) && int.TryParse(dateParts[2], out int year))
                {
                    var date = new DateTime(year, month, day).AddDays(1);
                    var newDate = date.ToString("dd/MM/yyyy");
                    Dates.Add(newDate);
                }
            }
        });

        // Commands thêm nhân viên
        AddEmployeeToShift1Command = new Command(() =>
        {
            // Thêm nhân viên giả lập vào Thu ngân của Ca 1
            Shift1Cashiers.Add(new Employee { Name = "Nhân viên mới", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0123456789", Role = "Thu ngân" });
            UpdateStatistics();
        });

        AddEmployeeToShift2Command = new Command(() =>
        {
            // Thêm nhân viên giả lập vào Thu ngân của Ca 2
            Shift2Cashiers.Add(new Employee { Name = "Nhân viên mới", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0123456789", Role = "Thu ngân" });
            UpdateStatistics();
        });

        AddEmployeeToShift3Command = new Command(() =>
        {
            // Thêm nhân viên giả lập vào Thu ngân của Ca 3
            Shift3Cashiers.Add(new Employee { Name = "Nhân viên mới", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0123456789", Role = "Thu ngân" });
            UpdateStatistics();
        });

        // Commands xóa nhân viên
        RemoveShift1CashierCommand = new Command<Employee>(employee =>
        {
            Shift1Cashiers.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift1BaristaCommand = new Command<Employee>(employee =>
        {
            Shift1Baristas.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift1WaiterCommand = new Command<Employee>(employee =>
        {
            Shift1Waiters.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift2CashierCommand = new Command<Employee>(employee =>
        {
            Shift2Cashiers.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift2BaristaCommand = new Command<Employee>(employee =>
        {
            Shift2Baristas.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift2WaiterCommand = new Command<Employee>(employee =>
        {
            Shift2Waiters.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift3CashierCommand = new Command<Employee>(employee =>
        {
            Shift3Cashiers.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift3BaristaCommand = new Command<Employee>(employee =>
        {
            Shift3Baristas.Remove(employee);
            UpdateStatistics();
        });
        RemoveShift3WaiterCommand = new Command<Employee>(employee =>
        {
            Shift3Waiters.Remove(employee);
            UpdateStatistics();
        });
    }

    private void UpdateDataForDate(string date)
    {
        // Giả lập: Cập nhật dữ liệu theo ngày
        Shift1Cashiers.Clear();
        Shift1Baristas.Clear();
        Shift1Waiters.Clear();
        Shift2Cashiers.Clear();
        Shift2Baristas.Clear();
        Shift2Waiters.Clear();
        Shift3Cashiers.Clear();
        Shift3Baristas.Clear();
        Shift3Waiters.Clear();

        if (date == "01/04/2025")
        {
            Shift1Cashiers.Add(new Employee { Name = "Nguyễn Văn A", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Thu ngân" });
            Shift1Baristas.Add(new Employee { Name = "Nguyễn Văn B", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Pha chế" });
            Shift1Waiters.Add(new Employee { Name = "Nguyễn Văn C", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Phục vụ" });

            Shift2Cashiers.Add(new Employee { Name = "Nguyễn Văn D", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Thu ngân" });
            Shift2Baristas.Add(new Employee { Name = "Nguyễn Văn E", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Pha chế" });
            Shift2Waiters.Add(new Employee { Name = "Nguyễn Văn F", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Phục vụ" });

            Shift3Cashiers.Add(new Employee { Name = "Nguyễn Văn G", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Thu ngân" });
            Shift3Baristas.Add(new Employee { Name = "Nguyễn Văn H", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Pha chế" });
            Shift3Waiters.Add(new Employee { Name = "Nguyễn Văn I", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856245", Role = "Phục vụ" });
        }
        else
        {
            Shift1Cashiers.Add(new Employee { Name = "Trần Văn A", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856246", Role = "Thu ngân" });
            Shift2Baristas.Add(new Employee { Name = "Trần Văn B", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856247", Role = "Pha chế" });
            Shift3Waiters.Add(new Employee { Name = "Trần Văn C", DOB = new DateOnly(2000, 1, 1), PhoneNumber = "0342856248", Role = "Phục vụ" });
        }

        UpdateStatistics();
    }

    private void UpdateStatistics()
    {
        OnPropertyChanged(nameof(TotalEmployees));
        OnPropertyChanged(nameof(TotalEmployeesShift2));
        OnPropertyChanged(nameof(TotalEmployeesShift3));
        OnPropertyChanged(nameof(Shift1CashierCount));
        OnPropertyChanged(nameof(Shift1BaristaCount));
        OnPropertyChanged(nameof(Shift1WaiterCount));
        OnPropertyChanged(nameof(Shift2CashierCount));
        OnPropertyChanged(nameof(Shift2BaristaCount));
        OnPropertyChanged(nameof(Shift2WaiterCount));
        OnPropertyChanged(nameof(Shift3CashierCount));
        OnPropertyChanged(nameof(Shift3BaristaCount));
        OnPropertyChanged(nameof(Shift3WaiterCount));
    }
}
