using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManagement.WinClient.Infrastructure
{
    public abstract class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await ExecuteCommandAsync(parameter);
        }

        protected abstract Task ExecuteCommandAsync(object parameter);
    }
}
