using System;
using System.Windows.Input;

namespace MVVM.LTE.Commands
{
    public class SimpleCommand:ICommand
    {

        public SimpleCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public SimpleCommand(Action execute, Func<bool> canExecute)
        {
            _action = execute;
            _func = canExecute;
        }
        public SimpleCommand(Action<object> execute)
           : this(execute, (x) => true)
        {
        }

        public SimpleCommand(Action execute)
          : this(execute, () => true)
        {
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return CanExecute();
            else
                return CanExecuteParam(parameter);
        }

        public void Execute(object parameter)
        {
            if (_action != null) _action();
            else _execute?.Invoke(parameter);
        }

        public bool CanExecute()
        {
            if (_func != null)
                return _func();
            else
                return false;
        }       

        public void OnCanExecuteChanged() => CanExecute();

        public void OnExecuteChanged()=> Execute(null);

        private bool CanExecuteParam(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);
            else
                return false;
        }
        private readonly Action _action;
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        private readonly Func<bool> _func;
    }
}
