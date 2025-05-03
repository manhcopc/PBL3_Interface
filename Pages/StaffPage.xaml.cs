using System.Collections.ObjectModel;
namespace PBL3_Interface.Pages;

class EmployeeViewModel
{
    public ObservableCollection<Employee> Employees { get; set; }
    public List<string> DepartmentList { get; set; }
    public string SelectedDepartment { get; set; }

    public EmployeeViewModel()
    {
        DepartmentList = new List<string>
        {
            "Tất cả", "Phục vụ", "Pha chế", "Thu ngân"
        };

        Employees = new ObservableCollection<Employee>
        {
            new Employee { Name = "Nguyễn Văn A", DOB = new DateOnly(2001,1,1), PhoneNumber = "0342885245", Address = "Da nang", Role = "Thu ngân" },
            new Employee { Name = "Nguyễn Văn B", DOB = new DateOnly(2002,1,1), PhoneNumber = "0342885245", Address = "Da nang", Role = "Pha chế" },
            new Employee { Name = "Nguyễn Văn C", DOB = new DateOnly(2003,1,1), PhoneNumber = "0342885245", Address = "Da nang", Role = "Phục vụ" },
            new Employee { Name = "Nguyễn Văn D", DOB = new DateOnly(2004,1,1), PhoneNumber = "0342885245", Address = "Da nang", Role = "Phục vụ" }
        };
    }
}

public class Employee
{
    public string Name { get; set; }
    public DateOnly DOB { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Role { get; set; }
}

public partial class StaffPage : ContentPage
{
    public StaffPage()
    {
        InitializeComponent();
        BindingContext = new EmployeeViewModel();

    }

}