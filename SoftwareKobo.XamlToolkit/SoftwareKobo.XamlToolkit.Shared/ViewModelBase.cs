using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
#if WinRT
using Windows.ApplicationModel;
#endif

namespace SoftwareKobo.XamlToolkit
{
    public abstract class ViewModelBase : ObserableObject
    {
        public bool IsInDesignMode
        {
            get
            {
                return IsInDesignModeStatic;
            }
        }

        public static bool IsInDesignModeStatic
        {
            get
            {                
#if WPF
                return (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
#endif
#if SILVERLIGHT
                return DesignerProperties.IsInDesignTool;
#endif
#if WinRT
                return DesignMode.DesignModeEnabled;       
#endif

                // TODO move message to resx
                throw new NotImplementedException("该平台暂未实现");
            }
        }
    }
}
