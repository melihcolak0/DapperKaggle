using _09PC_Dapper.Dtos.EmployeeDtos;
using _09PC_Dapper.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace _09PC_Dapper.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _employeeService.GetEmployeeListAsync();
            return View(values);
        }

        public async Task<IActionResult> EmployeeListWithDepartment()
        {
            var values = await _employeeService.GetEmployeeListWithDepartmentAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeService.CreateEmployeeAsync(createEmployeeDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var value = await _employeeService.GetEmployeeByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeService.UpdateEmployeeAsync(updateEmployeeDto);
            return RedirectToAction("Index");
        }
    }
}
