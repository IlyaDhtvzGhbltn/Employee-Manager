using EmployeeManagement.WinClient.DAL;
using EmployeeManagement.WinClient.Models;
using EmployeeManagement.WinClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.WinClient.Infrastructure.Commands
{
    public class AddEmploeeCommand : AsyncCommand
    {
        private readonly IDataProvider _dataProvider;
        private readonly AdminModeViewModel _adminModeViewModel;

        public AddEmploeeCommand(AdminModeViewModel adminModeViewModel, IDataProvider datatProvider)
        {
            _adminModeViewModel = adminModeViewModel;
            _dataProvider = datatProvider;
        }


        protected override async Task ExecuteCommandAsync(object parameter)
        {
            await Task.Run(async () => 
            {
                var newEmplModel = new EmployeeModel();
                newEmplModel.Name = _adminModeViewModel.NewEmploeeName;
                newEmplModel.Surname = _adminModeViewModel.NewEmploeeSurname;

                if (string.IsNullOrWhiteSpace(newEmplModel.Name) || string.IsNullOrWhiteSpace(newEmplModel.Surname))
                {
                    _adminModeViewModel.ErrorMessage = "Invalid Emploee Name";
                }
                else
                {
                    try
                    {
                        await _dataProvider.AddEmploee(newEmplModel);
                    }
                    catch (ArgumentException)
                    {
                        _adminModeViewModel.ErrorMessage = "Such Employee has been already added";
                    }
                    finally
                    {
                        _adminModeViewModel.UpdateListCommand.Execute(_adminModeViewModel.CurrentPage);
                    }
                }
            });
        }
    }
}
