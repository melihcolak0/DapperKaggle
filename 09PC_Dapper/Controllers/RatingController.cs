using _09PC_Dapper.Dtos.RatingDtos;
using _09PC_Dapper.Services.RatingServices;
using Microsoft.AspNetCore.Mvc;

namespace _09PC_Dapper.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 50, string search = "")
        {
            var (ratings, totalCount) = await _ratingService.GetRatingsPagedAsync(page, pageSize, search);

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

            return View(ratings);
        }


        [HttpGet]
        public IActionResult CreateRating()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRating(CreateRatingDto dto)
        {
            await _ratingService.CreateRatingAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRating(int userId, string isbn)
        {
            await _ratingService.DeleteRatingAsync(userId, isbn);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetRatingById(int userId, string isbn)
        {
            var value = await _ratingService.GetRatingByIdAsync(userId, isbn);
            return View(value);
        }
    }
}

