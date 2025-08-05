using _09PC_Dapper.Context;
using _09PC_Dapper.Dtos.UserDtos;
using Dapper;

namespace _09PC_Dapper.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DapperContext _context;

        public UserService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            string query = "INSERT INTO Users2(User_ID, Location, Age) VALUES(@User_ID, @Location, @Age)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, createUserDto);
        }

        public async Task DeleteUserAsync(int userId)
        {
            string query = "DELETE FROM Users2 WHERE User_ID = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = userId });
        }

        public async Task<List<ResultUserDto>> GetAllUsersAsync()
        {
            string query = "SELECT * FROM Users2";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultUserDto>(query);
            return values.ToList();
        }

        public async Task<GetUserByIdDto> GetUserByIdAsync(int userId)
        {
            string query = "SELECT * FROM Users2 WHERE User_ID = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetUserByIdDto>(query, new { Id = userId });
        }

        public async Task<(List<ResultUserDto> Users, int TotalCount)> GetUsersPagedAsync(int page, int pageSize, string search)
        {
            string whereClause = "";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(search))
            {
                // Burada sadece Location sütununda arama yapalım, çünkü diğer sütunlar yok
                whereClause = "WHERE Location LIKE @Search";
                parameters.Add("@Search", $"%{search}%");
            }

            string countQuery = $"SELECT COUNT(*) FROM users2 {whereClause};";
            string dataQuery = $@"
    SELECT User_ID, Location, Age
    FROM users2
    {whereClause}
    ORDER BY User_ID DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
";

            parameters.Add("@Offset", (page - 1) * pageSize);
            parameters.Add("@PageSize", pageSize);

            using var connection = _context.CreateConnection();
            var totalCount = await connection.ExecuteScalarAsync<int>(countQuery, parameters);
            var users = (await connection.QueryAsync<ResultUserDto>(dataQuery, parameters)).ToList();

            return (users, totalCount);
        }


        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            string query = "UPDATE Users2 SET Location = @Location, Age = @Age WHERE User_ID = @User_ID";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, updateUserDto);
        }
    }

}
