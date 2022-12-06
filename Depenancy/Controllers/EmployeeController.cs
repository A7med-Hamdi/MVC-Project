using Depenancy.Services;
using Depenancy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depenancy.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            List<Employee> employees = employeeService.getall();
            return View(employees);
        }
    }
}
