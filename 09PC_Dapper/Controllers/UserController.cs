using _09PC_Dapper.Dtos.UserDtos;
using _09PC_Dapper.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace _09PC_Dapper.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 50, string search = "")
        {
            var (users, totalCount) = await _userService.GetUsersPagedAsync(page, pageSize, search);

            int maxPagesToShow = 5;
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            int startPage = Math.Max(1, page - 2);
            int endPage = Math.Min(totalPages, startPage + maxPagesToShow - 1);

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            ViewBag.Search = search;

            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            await _userService.CreateUserAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var value = await _userService.GetUserByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
        {
            await _userService.UpdateUserAsync(dto);
            return RedirectToAction("Index");
        }
    }

}
