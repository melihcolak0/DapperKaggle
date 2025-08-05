using _09PC_Dapper.Dtos.UserDtos;

namespace _09PC_Dapper.Services.UserServices
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllUsersAsync();
        Task CreateUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
        Task DeleteUserAsync(int userId);
        Task<GetUserByIdDto> GetUserByIdAsync(int userId);
        Task<(List<ResultUserDto> Users, int TotalCount)> GetUsersPagedAsync(int page, int pageSize, string search);
    }
}
