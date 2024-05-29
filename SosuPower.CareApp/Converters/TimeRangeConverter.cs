using System.Globalization;

namespace SosuPower.CareApp.Converters
{
    public class TimeRangeConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] is DateTime start && values[1] is DateTime end)
            {
                return $"{start:HH.mm} - {end:HH.mm}";
            }
            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}