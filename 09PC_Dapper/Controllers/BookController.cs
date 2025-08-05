using _09PC_Dapper.Context;
using _09PC_Dapper.Dtos.BookDtos;
using _09PC_Dapper.Services.BookServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _09PC_Dapper.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly DapperContext _context;

        public BookController(IBookService bookService, DapperContext context)
        {
            _bookService = bookService;
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 50, string search = "")
        {
            var (books, totalCount) = await _bookService.GetBooksPagedAsync(page, pageSize, search);

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

            return View(books);
        }

        public async Task<IActionResult> Index2(int page = 1)
        {
            var books = await _bookService.GetBooksWithRatingsAsync(page, 9);

            return View(books);
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto dto)
        {
            await _bookService.CreateBookAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBook(string isbn)
        {
            await _bookService.DeleteBookAsync(isbn);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(string isbn)
        {
            var value = await _bookService.GetBookByIdAsync(isbn);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateBookDto dto)
        {
            await _bookService.UpdateBookAsync(dto);
            return RedirectToAction("Index");
        }
    }

}
