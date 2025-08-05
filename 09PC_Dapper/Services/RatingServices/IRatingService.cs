using _09PC_Dapper.Dtos.RatingDtos;

namespace _09PC_Dapper.Services.RatingServices
{
    public interface IRatingService
    {
        Task<List<ResultRatingDto>> GetAllRatingsAsync();
        Task CreateRatingAsync(CreateRatingDto createRatingDto);
        Task DeleteRatingAsync(int userId, string isbn);
        Task<GetRatingByIdDto> GetRatingByIdAsync(int userId, string isbn);
        Task<(List<ResultRatingDto> Ratings, int TotalCount)> GetRatingsPagedAsync(int page, int pageSize, string search);

    }

}
