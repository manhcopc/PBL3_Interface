using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace PBL3_Interface.Pages;

public partial class OrderPage : ContentPage
{
    public OrderPage()
    {
        InitializeComponent();
    }

}
// public class OrderStatsViewModel : INotifyPropertyChanged
// {
//     public event PropertyChangedEventHandler PropertyChanged;

//     protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
//     {
//         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//     }

//     private DateTime _selectedDate = DateTime.Now;
//     public DateTime SelectedDate
//     {
//         get => _selectedDate;
//         set { _selectedDate = value; OnPropertyChanged(); }
//     }

//     private ObservableCollection<Shift> _shifts = new ObservableCollection<Shift>
//     {
//         new Shift { Status = "Đang mở", Revenue = 500000, OrderCount = 10, Orders = new ObservableCollection<Order>
//             {
//                 new Order { Amount = 50000, OrderTime = DateTime.Now, Details = "Cà phê đen x2" },
//                 new Order { Amount = 30000, OrderTime = DateTime.Now.AddHours(-1), Details = "Trà sữa" }
//             }
//         },
//         new Shift { Status = "Đã đóng", Revenue = 300000, OrderCount = 5, Orders = new ObservableCollection<Order>
//             {
//                 new Order { Amount = 60000, OrderTime = DateTime.Now.AddDays(-1), Details = "Cà phê sữa" }
//             }
//         },
//         new Shift { Status = "Sắp mở", Revenue = 0, OrderCount = 0, Orders = new ObservableCollection<Order>() }
//     };
//     public ObservableCollection<Shift> Shifts
//     {
//         get => _shifts;
//         set { _shifts = value; OnPropertyChanged(); }
//     }

//     private Shift _selectedShift;
//     public Shift SelectedShift
//     {
//         get => _selectedShift;
//         set
//         {
//             _selectedShift = value;
//             SelectedShiftOrders = _selectedShift?.Orders ?? new ObservableCollection<Order>();
//             TotalShiftRevenue = _selectedShift?.Revenue ?? 0;
//             OnPropertyChanged();
//             OnPropertyChanged(nameof(SelectedShiftOrders));
//             OnPropertyChanged(nameof(TotalShiftRevenue));
//         }
//     }

//     private ObservableCollection<Order> _selectedShiftOrders = new ObservableCollection<Order>();
//     public ObservableCollection<Order> SelectedShiftOrders
//     {
//         get => _selectedShiftOrders;
//         set { _selectedShiftOrders = value; OnPropertyChanged(); }
//     }

//     private double _totalShiftRevenue;
//     public double TotalShiftRevenue
//     {
//         get => _totalShiftRevenue;
//         set { _totalShiftRevenue = value; OnPropertyChanged(); }
//     }

//     public ICommand FilterCommand { get; }
//     public ICommand ShiftSelectedCommand { get; }

//     public OrderStatsViewModel()
//     {
//         FilterCommand = new Command(() =>
//         {
//             // Logic lọc theo ngày (giả lập)
//             foreach (var shift in Shifts)
//             {
//                 shift.Orders.Clear();
//                 if (shift.Status == "Đang mở")
//                 {
//                     shift.Orders.Add(new Order { Amount = 50000, OrderTime = SelectedDate, Details = "Cà phê đen" });
//                 }
//             }
//             OnPropertyChanged(nameof(Shifts));
//         });

//         ShiftSelectedCommand = new Command<Shift>(shift =>
//         {
//             SelectedShift = shift;
//         });
//     }
// }

// // Model cho Shift
// public class Shift : INotifyPropertyChanged
// {
//     public event PropertyChangedEventHandler PropertyChanged;

//     private string _status;
//     private double _revenue;
//     private int _orderCount;
//     private ObservableCollection<Order> _orders;

//     public string Status
//     {
//         get => _status;
//         set { _status = value; OnPropertyChanged(); }
//     }

//     public double Revenue
//     {
//         get => _revenue;
//         set { _revenue = value; OnPropertyChanged(); }
//     }

//     public int OrderCount
//     {
//         get => _orderCount;
//         set { _orderCount = value; OnPropertyChanged(); }
//     }

//     public ObservableCollection<Order> Orders
//     {
//         get => _orders;
//         set { _orders = value; OnPropertyChanged(); }
//     }

//     protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
//     {
//         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//     }
// }

// // Model cho Order
// public class Order : INotifyPropertyChanged
// {
//     public event PropertyChangedEventHandler PropertyChanged;

//     private double _amount;
//     private DateTime _orderTime;
//     private string _details;

//     public double Amount
//     {
//         get => _amount;
//         set { _amount = value; OnPropertyChanged(); }
//     }

//     public DateTime OrderTime
//     {
//         get => _orderTime;
//         set { _orderTime = value; OnPropertyChanged(); }
//     }

//     public string Details
//     {
//         get => _details;
//         set { _details = value; OnPropertyChanged(); }
//     }

//     protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
//     {
//         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//     }
// }