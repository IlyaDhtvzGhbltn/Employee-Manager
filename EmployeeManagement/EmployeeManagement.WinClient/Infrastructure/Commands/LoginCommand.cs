using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.ViewModels;
using EmployeeManagement.WinClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            Thread.Sleep(10000);
            _authViewModel.Alert = "Please wait...";

            var passwordBox = parameter as PasswordBox;

            Permissions perms = await _authentication.Login(_authViewModel.Login, passwordBox.Password);
            if (perms == null)
            {
                _authViewModel.Alert = "Login or password incorrect.";
            }
            else 
            {
                Window secureWind = null;
                switch (perms.Role) 
                {
                    case "admin": secureWind = new AdminView();
                        break;
                    case "user": secureWind = new UserView();
                        break;
                    default: throw new NotImplementedException("Unexpected role was found");
                }
                secureWind.Show();
                _authViewModel.Close.Invoke();
            }
        }
    }
}
