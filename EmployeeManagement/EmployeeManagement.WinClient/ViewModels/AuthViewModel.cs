using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.Infrastructure;
using EmployeeManagement.WinClient.Infrastructure.Commands;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeManagement.WinClient.ViewModels
{
    public class AuthViewModel : ViewModelBase, IClose
    {
        private string _login;
        private string _alert;
        private DelegateCommand _closeCommand;

        private readonly AsyncCommand _loginCommand;
        private readonly IAuthentication _authentication;


        public ICommand LoginCommand => _loginCommand;
        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));


        public Action Close { get; set; }
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

        public void CloseWindow()
        {
            Close?.Invoke();
        }
    }
}
