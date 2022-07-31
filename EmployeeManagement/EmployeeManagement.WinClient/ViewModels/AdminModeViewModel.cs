using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.Infrastructure;
using EmployeeManagement.WinClient.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeManagement.WinClient.ViewModels
{
    public class AdminModeViewModel : EmploeeListViewModel
    {
        private readonly AsyncCommand _deleteEmploeeCommand;
        private readonly AsyncCommand _addEmploeeCommand;
        private readonly IDataProvider _dataProvider;

        private string _newEmploeeName;
        private string _newEmploeeSurname;
        private string _errorMessage;

        public string NewEmploeeName 
        {
            get { return _newEmploeeName; }
            set { SetProperty(ref _newEmploeeName, value); }
        }        
        
        public string NewEmploeeSurname 
        {
            get { return _newEmploeeSurname; }
            set { SetProperty(ref _newEmploeeSurname, value); }
        }

        public string ErrorMessage 
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }
        public ICommand DeleteEmploeeCommand => _deleteEmploeeCommand;
        public ICommand AddEmploeeCommand => _addEmploeeCommand;

        public AdminModeViewModel()
        {
            _dataProvider = new SimplestDataProvider();
            _deleteEmploeeCommand = new DeleteEmploeeCommand(this, _dataProvider);
            _addEmploeeCommand = new AddEmploeeCommand(this, _dataProvider);
        }
    }
}
