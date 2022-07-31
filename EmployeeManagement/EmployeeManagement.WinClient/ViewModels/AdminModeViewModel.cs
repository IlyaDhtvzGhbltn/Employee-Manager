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
        private readonly IDataProvider _dataProvider;


        public ICommand DeleteEmploeeCommand => _deleteEmploeeCommand;

        public AdminModeViewModel()
        {
            _dataProvider = new SimplestDataProvider();
            _deleteEmploeeCommand = new DeleteEmploeeCommand(this, _dataProvider);
        }
    }
}
