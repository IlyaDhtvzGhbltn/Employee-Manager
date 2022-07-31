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
            var perms = new Permissions();
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            await Task.Run(async () => 
            {
                _authViewModel.Alert = "Please wait...";

                var passwordBox = parameter as PasswordBox;

                perms = await _authentication.Login(_authViewModel.Login, passwordBox.Password);
                if (perms == null)
                {
                    _authViewModel.Alert = "Login or password incorrect.";
                }
            }).ContinueWith((r)=> 
            {
                switch (perms.Role)
                {
                    case "user":
                        var userView = new UserView();
                        userView.Show();
                        break;
                    case "admin":
                        var adminView = new AdminView();
                        adminView.Show();
                        break;
                };
                _authViewModel.Close.Invoke();

            }, scheduler);
        }
    }
}