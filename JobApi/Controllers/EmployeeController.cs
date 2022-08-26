using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApi.Models;
using JobApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeServices _employeeservice;
        public EmployeeController(EmployeeServices employeeservice)
        {
            _employeeservice = employeeservice;
        }

        [HttpPost("create-employee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeservice.CreateEmployee(employee);
            return Ok();
        }

        [HttpGet("read-all-employees")]
        public IActionResult ReadAllEmployees()
        {
            var allEmployees = _employeeservice.ReadAllEmployees();
            return Ok(allEmployees);
        }

        [HttpGet("read-employee/{name}")]
        public IActionResult ReadEmployeeByName(string name)
        {
            var employee = _employeeservice.ReadEmployeeByName(name);
            return Ok(employee);
        }

        [HttpPut("update-employee-by-id")]
        public IActionResult UpdateEmployeeById(Employee employee)
        {
            var updateEmployee = _employeeservice.UpdateEmployeeById(employee);
            return Ok(updateEmployee);
        }

        [HttpDelete("delete-employee-by-id/{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            _employeeservice.DeleteEmployeeById(id);
            return Ok();
        }

    }
}