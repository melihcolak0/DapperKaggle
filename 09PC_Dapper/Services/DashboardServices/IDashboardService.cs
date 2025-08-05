using _09PC_Dapper.Dtos.DashboardDtos;

namespace _09PC_Dapper.Services.DashboardServices
{
    public interface IDashboardService
    {
        Task<DashboardStatisticsDto> GetStatisticsAsync();
        Task<List<ChartDto>> GetRatingDistributionAsync();

    }
}
