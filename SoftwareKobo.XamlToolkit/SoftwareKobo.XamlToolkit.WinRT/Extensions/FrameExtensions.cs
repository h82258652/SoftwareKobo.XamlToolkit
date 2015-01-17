using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace SoftwareKobo.XamlToolkit.Extensions
{
    public static class FrameExtensions
    {
        public static bool Navigate<TSourcePage>(this Frame frame) where TSourcePage : Page
        {
            return frame.Navigate(typeof(TSourcePage));
        }

        public static bool Navigate<TSourcePage>(this Frame frame, object parameter) where TSourcePage : Page
        {
            return frame.Navigate(typeof(TSourcePage), parameter);
        }

        public static bool Navigate<TSourcePage>(this Frame frame, object parameter, NavigationTransitionInfo infoOverride) where TSourcePage : Page
        {
            return frame.Navigate(typeof(TSourcePage), parameter, infoOverride);
        }
    }
}
