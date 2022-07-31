using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.Models;
using EmployeeManagement.WinClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.WinClient.Infrastructure.Commands
{
    public class DeleteEmploeeCommand : AsyncCommand
    {
        private readonly IDataProvider _dataProvider;
        private readonly AdminModeViewModel _adminModeViewModel;

        public DeleteEmploeeCommand(AdminModeViewModel adminModeViewModel, IDataProvider datatProvider)
        {
            _adminModeViewModel = adminModeViewModel;
            _dataProvider = datatProvider;
        }

        protected override async Task ExecuteCommandAsync(object parameter)
        {
            await Task.Run(async () => 
            {
                EmployeeModel model = parameter as EmployeeModel;
                await _dataProvider.DeleteEmploee(model.Id);
                _adminModeViewModel.UpdateListCommand.Execute(_adminModeViewModel.CurrentPage);
            });
        }
    }
}
