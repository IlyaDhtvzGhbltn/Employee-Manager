using EmployeeManagement.Entities;
using EmployeeManagement.WinClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.WinClient.DAL
{
    public interface IDataProvider
    {
        Task<ObservableCollection<EmployeeModel>> GetEmployeeList(int count, int skip);
        Task<int> GetEmploeeCount();
        Task DeleteEmploee(int Id);
    }
}
