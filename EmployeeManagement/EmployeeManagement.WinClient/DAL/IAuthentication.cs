using EmployeeManagement.WinClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.WinClient.DAL
{
    public interface IAuthentication
    {
        Task<Permissions> Login(string login, string password);
    }
}
