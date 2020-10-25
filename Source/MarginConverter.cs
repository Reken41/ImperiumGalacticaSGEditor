using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ImperiumGalacticaEditor
{
  public class MarginConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return new Thickness(((Planet)value).X, ((Planet)value).Y, 0, 0);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return null;
    }
  }

  public class MultiConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      return new Thickness(System.Convert.ToDouble(values[0]), System.Convert.ToDouble(values[1]), 0, 0);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      return null;
    }
  }
}
