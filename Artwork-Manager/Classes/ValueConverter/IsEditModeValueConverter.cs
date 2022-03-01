using System.Globalization;
using Avalonia.Data.Converters;

namespace ArtworkManager.Classes.ValueConverter;

public class IsEditModeValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == default) return default;
        
        var x = (bool) value;

        return x ? "Save changes" : "Save artwork to database";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}