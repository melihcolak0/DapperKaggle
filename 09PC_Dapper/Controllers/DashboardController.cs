using _09PC_Dapper.Dtos.DashboardDtos;
using _09PC_Dapper.Services.DashboardServices;
using Microsoft.AspNetCore.Mvc;

namespace _09PC_Dapper.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dashboardService.GetStatisticsAsync();

            model.RatingDistribution = await _dashboardService.GetRatingDistributionAsync();
            
            return View(model);
        }
    }
}
