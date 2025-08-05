using _09PC_Dapper.Dtos.DepartmentDtos;

namespace _09PC_Dapper.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentsAsync();
        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(int id);
        Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id);
    }
}
