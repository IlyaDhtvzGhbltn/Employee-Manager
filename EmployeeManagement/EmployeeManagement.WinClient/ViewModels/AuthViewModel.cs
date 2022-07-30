using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.Infrastructure;
using EmployeeManagement.WinClient.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeManagement.WinClient.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        private string _login;
        private string _password;
        private string _alert;
        private readonly AsyncCommand _loginCommand;
        private readonly IAuthentication _authentication;

        public ICommand LoginCommand => _loginCommand;

        public string Login 
        {
            get 
            { 
                return _login; 
            }
            set 
            {
                SetProperty(ref _login, value);
            }
        }        
        public string Password 
        {
            get 
            { 
                return _password; 
            }
            set 
            {
                SetProperty(ref _password, value);
            }
        }
        public string Alert 
        {
            get 
            {
                return _alert;
            }
            set 
            {
                SetProperty(ref _alert, value);
            }
        }

        public AuthViewModel()
        {
            _authentication = new SimplestAuthentication();
            _loginCommand = new LoginCommand(this, _authentication);
        }
    }
}
