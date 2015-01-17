#if !WINDOWS_FORM_APP
using System;
#if WPF||SILVERLIGHT
using System.Globalization;
using System.Windows;
using System.Windows.Data;
#endif
#if WinRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace SoftwareKobo.XamlToolkit.Converters
{
    public class VisibilityToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
#if WPF||SILVERLIGHT
            CultureInfo culture
#endif
#if WinRT
            string language
#endif
            )
        {
            if (value is Visibility)
            {
                return (Visibility)value == Visibility.Visible;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
#if WPF||SILVERLIGHT
            CultureInfo culture
#endif
#if WinRT
            string language
#endif
            )
        {
            bool bValue = false;
            if (value is bool)
            {
                bValue = (bool)value;
            }
            else if (value is bool?)
            {
                bool? tmp = (bool?)value;
                bValue = tmp.HasValue ? tmp.Value : false;
            }
            return (bValue) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
#endif