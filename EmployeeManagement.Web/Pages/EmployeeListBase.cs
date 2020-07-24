using EmployeeManagement.Models;
using EmployeeManagement.Web.Service;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
            //await Task.Run(LoadEmployees);
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
        protected int SelectedEmployeesCount { get; set; } = 0;
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if(isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }
        //private void LoadEmployees ()
        //{
        //    System.Threading.Thread.Sleep(3000);
        //    Employee e1 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "John",
        //        LastName = "Jones",
        //        Email = "john@gmail.com",
        //        DateOfBirth = new DateTime(1980, 10, 5),
        //        Gender = Gender.Male,
        //        DepartmentId = 1,
        //        PhotoPath = "images/john.png"
        //    };

        //    Employee e2 = new Employee
        //    {
        //        EmployeeId = 2,
        //        FirstName = "Jack",
        //        LastName = "Downing",
        //        Email = "jack@gmail.com",
        //        DateOfBirth = new DateTime(1956, 10, 5),
        //        Gender = Gender.Male,
        //        DepartmentId = 4,
        //        PhotoPath = "images/jack.jpg"
        //    };

        //    Employee e3 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Jane",
        //        LastName = "Doe",
        //        Email = "jane@gmail.com",
        //        DateOfBirth = new DateTime(1987, 6, 7),
        //        Gender = Gender.Female,
        //        DepartmentId = 2,
        //        PhotoPath = "images/jane.png"
        //    };

        //    Employee e4 = new Employee
        //    {
        //        EmployeeId = 4,
        //        FirstName = "Mary",
        //        LastName = "Martha",
        //        Email = "mary@gmail.com",
        //        DateOfBirth = new DateTime(1975, 12, 7),
        //        Gender = Gender.Female,
        //        DepartmentId = 3,
        //        PhotoPath = "images/mary.png"
        //    };

        //    Employees = new List<Employee> { e1, e2, e3, e4 };
        //}
    }
}
