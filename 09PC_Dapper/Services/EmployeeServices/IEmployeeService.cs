using _09PC_Dapper.Dtos.EmployeeDtos;

namespace _09PC_Dapper.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<ResultEmployeeDto>> GetEmployeeListAsync();
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployeeAsync(int id);
        Task<GetEmployeeByIdDto> GetEmployeeByIdAsync(int id);
        Task<List<ResultEmployeeWithDepartmentDto>> GetEmployeeListWithDepartmentAsync();
    }
}
