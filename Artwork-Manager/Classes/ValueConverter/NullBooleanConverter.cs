using System.Globalization;
using Avalonia.Data.Converters;

namespace ArtworkManager.Classes.ValueConverter;

public class NullBooleanConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != default;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}