using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services;

internal class MockEmployeeRepository : IEmployeeRepository
{
    private List<Employee> _employeeList;

    public MockEmployeeRepository()
    {
        _employeeList = new List<Employee>()
        {
            new() { Id = 0, Name = "Mary", Email = "mary@mail.com", PhotoPath = "avatar1.jpg", Department = Department.HR },
            new() { Id = 0, Name = "Mark", Email = "mark@mail.com", PhotoPath = "avatar2.jpg", Department = Department.IT },
            new() { Id = 0, Name = "Jenn", Email = "jenn@mail.com", PhotoPath = "avatar3.jpg", Department = Department.Payroll },
        };
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

}
