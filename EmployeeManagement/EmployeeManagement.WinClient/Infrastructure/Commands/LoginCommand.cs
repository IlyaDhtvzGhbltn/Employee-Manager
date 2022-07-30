using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.ViewModels;
using EmployeeManagement.WinClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement.WinClient.Infrastructure.Commands
{
    public class LoginCommand : AsyncCommand
    {
        private readonly AuthViewModel _authViewModel;
        private readonly IAuthentication _authentication;

        public LoginCommand(AuthViewModel authViewModel, IAuthentication authentication)
        {
            _authViewModel = authViewModel;
            _authentication = authentication;
        }

        protected override async Task ExecuteCommandAsync(object parameter)
        {
            _authViewModel.Alert = "Please wait...";

            await _authentication.Login(_authViewModel.Login, _authViewModel.Password);
        }
    }
}
