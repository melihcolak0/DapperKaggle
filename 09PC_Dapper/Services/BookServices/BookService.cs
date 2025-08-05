using _09PC_Dapper.Context;
using _09PC_Dapper.Dtos.BookDtos;
using _09PC_Dapper.Dtos.DepartmentDtos;
using Dapper;

namespace _09PC_Dapper.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly DapperContext _context;

        public BookService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateBookAsync(CreateBookDto createBookDto)
        {
            string query = "INSERT INTO Books(ISBN, BookTitle, BookAuthor, YearOfPublication, Publisher) VALUES(@ISBN, @Title, @Author, @Year, @Publisher)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, createBookDto);
        }

        public async Task DeleteBookAsync(string isbn)
        {
            string query = "DELETE FROM Books WHERE ISBN = @ISBN";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { ISBN = isbn });
        }

        public async Task<List<ResultBookDto>> GetAllBooksAsync()
        {
            string query = "SELECT * FROM Books";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultBookDto>(query);
            return values.ToList();
        }

        public async Task<GetBookByIdDto> GetBookByIdAsync(string isbn)
        {
            string query = "SELECT * FROM Books WHERE ISBN = @ISBN";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetBookByIdDto>(query, new { ISBN = isbn });
        }

        public async Task UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            string query = "UPDATE Books SET BookTitle = @Title, BookAuthor = @Author, YearOfPublication = @Year, Publisher = @Publisher WHERE ISBN = @ISBN";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, updateBookDto);
        }

        public async Task<(List<ResultBookDto> Books, int TotalCount)> GetBooksPagedAsync(int page, int pageSize, string search)
        {
            using var connection = _context.CreateConnection();

            var offset = (page - 1) * pageSize;
            var whereClause = "";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(search))
            {
                whereClause = "WHERE Book_Title LIKE @Search OR Book_Author LIKE @Search";
                parameters.Add("@Search", $"%{search}%");
            }

            string countQuery = $"SELECT COUNT(*) FROM books {whereClause}";
            string dataQuery = $@"
                                    SELECT * FROM books
                                    {whereClause}
                                    ORDER BY Book_Title
                                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            parameters.Add("@Offset", offset);
            parameters.Add("@PageSize", pageSize);

            var totalCount = await connection.ExecuteScalarAsync<int>(countQuery, parameters);
            var books = await connection.QueryAsync<ResultBookDto>(dataQuery, parameters);

            return (books.ToList(), totalCount);
        }

        public async Task<List<BookWithRatingDto>> GetBooksWithRatingsAsync(int page = 1, int pageSize = 9)
        {
            using var connection = _context.CreateConnection();

            var query = @"SELECT 
    b.Book_Title AS BookTitle,
    b.Book_Author AS Author,
    b.Image_URL_L AS ImageUrl,
    b.Year_Of_Publication AS YearOfPublication,
    b.Publisher,
    ISNULL(AVG(r.Book_Rating), 0) AS Rating
FROM books b
LEFT JOIN ratings r ON b.ISBN = r.ISBN
WHERE b.Book_Title IN (
    'Monk''s-hood',
    'Made in America',
    'Nothing Can Be Better',
    'Daughters of the Storm',
    'Dark Spectre',
    'Sir Gawain and the Green Knight',
    'Pearl and Sir Orfeo',
    'Cereus Blooms At Night',
    'Farmer Giles of Ham: And Other Stories'
)
GROUP BY 
    b.Book_Title,
    b.Book_Author,
    b.Image_URL_L,
    b.Year_Of_Publication,
    b.Publisher
ORDER BY Rating DESC, b.Year_Of_Publication DESC;
";

            var books = await connection.QueryAsync<BookWithRatingDto>(query, new
            {
                Offset = (page - 1) * pageSize,
                PageSize = pageSize
            });

            return books.ToList();
        }
    }
}
