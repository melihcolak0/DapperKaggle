using _09PC_Dapper.Context;
using _09PC_Dapper.Dtos.RatingDtos;
using Dapper;

namespace _09PC_Dapper.Services.RatingServices
{
    public class RatingService : IRatingService
    {
        private readonly DapperContext _context;

        public RatingService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateRatingAsync(CreateRatingDto createRatingDto)
        {
            string query = "INSERT INTO Ratings(User_ID, ISBN, Book_Rating) VALUES(@User_ID, @ISBN, @Book_Rating)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, createRatingDto);
        }

        public async Task DeleteRatingAsync(int userId, string isbn)
        {
            string query = "DELETE FROM Ratings WHERE User_ID = @UserId AND ISBN = @Isbn";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { UserId = userId, Isbn = isbn });
        }

        public async Task<List<ResultRatingDto>> GetAllRatingsAsync()
        {
            string query = "SELECT * FROM Ratings";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultRatingDto>(query);
            return values.ToList();
        }

        public async Task<GetRatingByIdDto> GetRatingByIdAsync(int userId, string isbn)
        {
            string query = "SELECT * FROM Ratings WHERE User_ID = @UserId AND ISBN = @Isbn";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetRatingByIdDto>(query, new { UserId = userId, Isbn = isbn });
        }

        public async Task<(List<ResultRatingDto> Ratings, int TotalCount)> GetRatingsPagedAsync(int page, int pageSize, string search)
        {
            string whereClause = "";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(search))
            {
                whereClause = "WHERE CAST(User_ID AS VARCHAR) LIKE @Search OR CAST(ISBN AS VARCHAR) LIKE @Search";
                parameters.Add("@Search", $"%{search}%");
            }

            string countQuery = $"SELECT COUNT(*) FROM ratings {whereClause};";

            string dataQuery = $@"
        SELECT User_ID, ISBN, Book_Rating
        FROM ratings
        {whereClause}
        ORDER BY User_ID DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    ";

            parameters.Add("@Offset", (page - 1) * pageSize);
            parameters.Add("@PageSize", pageSize);

            using var connection = _context.CreateConnection();
            var totalCount = await connection.ExecuteScalarAsync<int>(countQuery, parameters);
            var ratings = (await connection.QueryAsync<ResultRatingDto>(dataQuery, parameters)).ToList();

            return (ratings, totalCount);
        }

    }
}
