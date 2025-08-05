using _09PC_Dapper.Context;
using _09PC_Dapper.Dtos.DepartmentDtos;
using _09PC_Dapper.Dtos.EmployeeDtos;
using Dapper;

namespace _09PC_Dapper.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DapperContext _context;

        public DepartmentService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            string query = "INSERT INTO Departments(DepartmentName) VALUES(@p1)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", createDepartmentDto.DepartmentName);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            string query = "DELETE FROM Departments WHERE DepartmentId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultDepartmentDto>> GetAllDepartmentsAsync()
        {
            string query = "SELECT * FROM Departments";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultDepartmentDto>(query);
            return values.ToList();
        }

        public async Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id)
        {
            string query = "SELECT * FROM Departments WHERE DepartmentId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            var value = await connection.QueryFirstAsync<GetDepartmentByIdDto>(query, parameters);
            return value;
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            string query = "UPDATE Departments SET DepartmentName=@DepartmentName WHERE DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentName", updateDepartmentDto.DepartmentName);
            parameters.Add("@DepartmentId", updateDepartmentDto.DepartmentId);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
