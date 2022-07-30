using EmployeeManagement.WinClient.Infrastructure;
using EmployeeManagement.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.WinClient.DAL
{
    public class SimplestAuthentication : IAuthentication
    {
        public async Task<Permissions> Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                return null;
            if (string.IsNullOrWhiteSpace(password))
                return null;

            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            string base64Text = Convert.ToBase64String(plainTextBytes);

            using (var context = new EmployeeDBContext()) 
            {
                Permissions userRole = await context.WinClientUsers
                    .Where(x => x.Login == login && x.PasswordHash == base64Text)
                    .Select(x => new Permissions() { Role = x.Role })
                    .FirstOrDefaultAsync();
                return userRole;
            }
        }
    }
}
