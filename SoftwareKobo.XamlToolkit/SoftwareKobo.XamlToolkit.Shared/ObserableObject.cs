using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftwareKobo.XamlToolkit
{
    public abstract class ObserableObject : INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged(
#if !SILVERLIGHT
            [CallerMemberName]
#endif
            string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            var body = propertyExpression.Body as MemberExpression;
            if (body == null)
            {
                // TODO move message to resx
                throw new ArgumentException("不是属性访问的表达式树。", nameof(propertyExpression));
            }

            var property = body.Member as PropertyInfo;
            if (property == null)
            {
                // TODO add message
                throw new ArgumentException("", nameof(propertyExpression));
            }

            RaisePropertyChanged(property.Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
