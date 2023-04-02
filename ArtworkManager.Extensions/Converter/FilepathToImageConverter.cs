using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace ArtworkManager.Extensions.Converter;

public class FilepathToImageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null) return default;

        try
        {
            var bitmap = new Bitmap(value as string);

            return bitmap;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}