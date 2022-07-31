using EmployeeManagement.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.WinClient.Models;
using System.Collections.ObjectModel;
using System;

namespace EmployeeManagement.WinClient.DAL
{
    public class SimplestDataProvider : IDataProvider
    {
        public async Task AddEmploee(EmployeeModel emploeeModel)
        {
            using (var context = new EmployeeDBContext())
            {
                var oldEmpl = await context.Employees
                    .FirstOrDefaultAsync(x => x.Name == emploeeModel.Name && x.Surname == emploeeModel.Surname);

                if(oldEmpl != null)
                {
                    throw new ArgumentException();
                }

                var newEmpl = new Employee() 
                {
                    Name = emploeeModel.Name, 
                    Surname = emploeeModel.Surname
                };
                context.Employees.Add(newEmpl);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmploee(int id)
        {
            using (var context = new EmployeeDBContext()) 
            {
                var emploee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                context.Remove(emploee);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetEmploeeCount()
        {
            using (var context = new EmployeeDBContext())
            {
                return await context.Employees.CountAsync();
            }
        }

        public async Task<ObservableCollection<EmployeeModel>> GetEmployeeList(int count, int skip)
        {
            using (var context = new EmployeeDBContext())
            {
                List<EmployeeModel> list = await context.Employees
                    .Skip(skip)
                    .Take(count)
                    .Select(x => new EmployeeModel() { Id = x.Id, Name = x.Name, Surname = x.Surname })
                    .ToListAsync();

                return new ObservableCollection<EmployeeModel>(list);
            }
        }
    }
}
