using _09PC_Dapper.Dtos.DepartmentDtos;
using _09PC_Dapper.Services.DepartmentServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _09PC_Dapper.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _departmentService.GetAllDepartmentsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _departmentService.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(int id)
        {
            var value = await _departmentService.GetDepartmentByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentDto);
            return RedirectToAction("Index");
        }
    }
}
