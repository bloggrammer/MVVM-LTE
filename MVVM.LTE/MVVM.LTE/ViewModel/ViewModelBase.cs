using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace MVVM.LTE.ViewModel
{
    public abstract class ViewModelBase: INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var expression = (MemberExpression)propertyExpression.Body;
            RaisePropertyChanged(expression.Member.Name);
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
