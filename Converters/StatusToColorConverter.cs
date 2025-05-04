using Microsoft.Maui.Controls;

namespace PBL3_Interface.Converters;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is string status)
        {
            switch (status)
            {
                case "Đang mở":
                    return Color.FromHex("#90EE90"); // Xanh lá nhạt
                case "Đã đóng":
                    return Color.FromHex("#FFB6C1"); // Hồng nhạt
                case "Sắp mở":
                    return Color.FromHex("#ADD8E6"); // Xanh dương nhạt
                default:
                    return Color.FromHex("#E6E6E6"); // Xám nhạt
            }
        }
        return Color.FromHex("#E6E6E6");
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}