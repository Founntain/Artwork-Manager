using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace ArtworkManager.Classes.ValueConverter;

public class BitmapValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
            return null;

        if (value is string && targetType.IsAssignableFrom(typeof(Bitmap)))
        {
            return new Bitmap((string) value);
        }

        throw new NotSupportedException();
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}