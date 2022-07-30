﻿using EmployeeManagement.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.WinClient.Models;
using System.Collections.ObjectModel;

namespace EmployeeManagement.WinClient.DAL
{
    public class SimplestDataProvider : IDataProvider
    {
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