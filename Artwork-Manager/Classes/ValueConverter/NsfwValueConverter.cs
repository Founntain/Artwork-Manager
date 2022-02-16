using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace ArtworkManager.Classes.ValueConverter;

public class NsfwValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var x = (bool) value;
        
        if (x)
        {
            return new SolidColorBrush(Colors.Red);
        }
        
        return new SolidColorBrush(Colors.Black);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var brush = (SolidColorBrush) value;

        if (brush.Color == Colors.Red)
        {
            return true;
        }

        return false;
    }
}