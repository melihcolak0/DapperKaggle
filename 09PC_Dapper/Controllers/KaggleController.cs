using _09PC_Dapper.Services.BookServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _09PC_Dapper.Controllers
{
    public class KaggleController : Controller
    {
        private readonly IBookService _bookService;

        public KaggleController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BookList()
        {
            var values = await _bookService.GetAllBooksAsync();
            return View(values);
        }
    }
}
