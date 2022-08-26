using JobApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Services
{
    public class EmployeeServices
    {
        private DBContext _context;

        public EmployeeServices(DBContext context)
        {
            _context = context;
        }

        // Create employee into table
        public void CreateEmployee(Employee employee)
        {
            var _employee = new Employee()
            {
                Name = employee.Name,
                Department = employee.Department,
                Position = employee.Position,
                Email = employee.Email
            };
            _context.Employees.Add(_employee);
            _context.SaveChanges();
        }

        // Read all the employees data from the database table
        public List<Employee> ReadAllEmployees() => _context.Employees.ToList();

        // Read employee data by name
        public List<Employee> ReadEmployeeByName(string name)
        {
            var _data = _context.Employees
                .Where(n => n.Name == name)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            return _data;
        }

        // Update Employee
        public Employee UpdateEmployeeById(Employee employee)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.EmployeeId == employee.EmployeeId);
            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Department = employee.Department;
                _employee.Position = employee.Position;
                _employee.Email = employee.Email;

                _context.SaveChanges();
            }
            return _employee;
        }

        // Delete Employee
        public void DeleteEmployeeById(int employeeId)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.EmployeeId == employeeId);
            if (_employee != null)
            {
                _context.Employees.Remove(_employee);
                _context.SaveChanges();
            }
        }

    }
}
