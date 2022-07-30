using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Entities
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext() : base(GetOptions("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagementDb;Integrated Security=true"))
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] names = new string[] { "John", "Oliver", "Jack", "Harry", "Jacob", "Charley", "Thomas" };

            modelBuilder.Entity<WinClientUser>()
                .HasData(
                new WinClientUser() { Id= 1, Login= "Admin", PasswordHash= "QWRtaW4=", Role= "admin" },
                new WinClientUser() { Id= 2,  Login="User", PasswordHash= "VXNlcg==", Role= "user" });

            for (int i = 1; i < 150; i++)
            {
                var rand = new Random();
                modelBuilder.Entity<Employee>()
                    .HasData(new Employee() { Id= i, Name = names[rand.Next(0, names.Length - 1)], Surname= "Doe" });
            }
        }


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<WinClientUser> WinClientUsers { get; set; }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
