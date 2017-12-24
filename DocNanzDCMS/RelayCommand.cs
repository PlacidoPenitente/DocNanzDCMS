using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DocNanzDCMS
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> executeCommand;
        private Func<object, bool> canExecuteCommand;

        public RelayCommand(Action<object> executeCommand, Func<object, bool> canExecuteCommand)
        {
            this.executeCommand = executeCommand;
            this.canExecuteCommand = canExecuteCommand;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeCommand(parameter);
        }
    }
}
