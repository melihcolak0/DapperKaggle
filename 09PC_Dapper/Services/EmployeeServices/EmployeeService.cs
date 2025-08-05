using _09PC_Dapper.Context;
using _09PC_Dapper.Dtos.EmployeeDtos;
using Dapper;

namespace _09PC_Dapper.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DapperContext _context;

        public EmployeeService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultEmployeeDto>> GetEmployeeListAsync()
        {
            string query = "SELECT * FROM Employees";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultEmployeeDto>(query);
            return values.ToList();
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "INSERT INTO Employees(Name, Surname, Salary) VALUES(@Name, @Surname, @Salary)";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", createEmployeeDto.Name);
            parameters.Add("@Surname", createEmployeeDto.Surname);
            parameters.Add("@Salary", createEmployeeDto.Salary);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "UPDATE Employees SET Name = @Name, Surname = @Surname, Salary = @Salary WHERE EmployeeId=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", updateEmployeeDto.Name);
            parameters.Add("@Surname", updateEmployeeDto.Surname);
            parameters.Add("@Salary", updateEmployeeDto.Salary);
            parameters.Add("@Id", updateEmployeeDto.EmployeeId);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            string query = "DELETE FROM Employees WHERE EmployeeId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetEmployeeByIdDto> GetEmployeeByIdAsync(int id)
        {
            string query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<GetEmployeeByIdDto>(query, parameters);
            return value;
        }

        public async Task<List<ResultEmployeeWithDepartmentDto>> GetEmployeeListWithDepartmentAsync()
        {
            string query = "SELECT EmployeeId, Name, Surname, Salary, DepartmentName FROM Employees INNER JOIN Departments ON Employees.DepartmentId=Departments.DepartmentId";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultEmployeeWithDepartmentDto>(query);
            return values.ToList();
        }
    }
}
