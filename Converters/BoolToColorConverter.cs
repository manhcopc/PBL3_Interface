using Microsoft.Maui.Controls;
using System.Globalization;

namespace PBL3_Interface.Converters;

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isSelected && isSelected)
        {
            return parameter?.ToString() == "Active" ? Color.FromHex("#4A90E2") : Color.FromHex("#E6F3FA");
        }
        return Color.FromHex("#E6E6E6");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}