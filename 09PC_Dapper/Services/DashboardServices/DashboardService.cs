using _09PC_Dapper.Context;
using _09PC_Dapper.Dtos.BookDtos;
using _09PC_Dapper.Dtos.DashboardDtos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace _09PC_Dapper.Services.DashboardServices
{
    public class DashboardService : IDashboardService
    {
        private readonly DapperContext _context;

        public DashboardService(DapperContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatisticsDto> GetStatisticsAsync()
        {
            var dto = new DashboardStatisticsDto();
            using var connection = _context.CreateConnection();

            // Toplam kitap sayısı
            dto.TotalBookCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM books");

            // En yüksek ratinge sahip kitap
            var maxRatedBook = await connection.QueryFirstOrDefaultAsync<(string BookTitle, float Rating)>(
                @"SELECT TOP 1 b.Book_Title, r.Book_Rating
          FROM ratings r
          JOIN books b ON r.ISBN = b.ISBN
          ORDER BY r.Book_Rating DESC");

            dto.MaxRatedBookTitle = maxRatedBook.BookTitle;
            dto.MaxRating = maxRatedBook.Rating;

            // En düşük ratinge sahip kitap
            var minRatedBook = await connection.QueryFirstOrDefaultAsync<(string BookTitle, float Rating)>(
                @"SELECT TOP 1 b.Book_Title, r.Book_Rating
          FROM ratings r
          JOIN books b ON r.ISBN = b.ISBN
          ORDER BY r.Book_Rating ASC");

            dto.MinRatedBookTitle = minRatedBook.BookTitle;
            dto.MinRating = minRatedBook.Rating;

            // Ortalama yaş (0 olanları dahil etme)
            dto.AverageUserAge = await connection.ExecuteScalarAsync<double>(
                @"SELECT AVG(CAST(Age AS FLOAT))
          FROM users2
          WHERE Age > 0");

            // Toplam kullanıcı sayısı
            var userCountQuery = "SELECT COUNT(*) FROM users2";
            dto.TotalUserCount = await connection.ExecuteScalarAsync<int>(userCountQuery);

            // 2000 sonrası basılan kitap sayısı (varsayılan sütun adı PublishYear)
            var booksAfter2000Query = "SELECT COUNT(*) FROM books WHERE Year_Of_Publication > 2000";
            dto.BooksPublishedAfter2000 = await connection.ExecuteScalarAsync<int>(booksAfter2000Query);

            // BooksByPublisher
            var publisherStats = await connection.QueryAsync<ChartDto>(@"
    SELECT TOP 5 Publisher AS Label, COUNT(*) AS Value
    FROM books
    GROUP BY Publisher
    ORDER BY Value DESC");
            dto.BooksByPublisher = publisherStats.ToList();

            // BooksByYear
            var yearStats = await connection.QueryAsync<ChartDto>(@"
        SELECT Year_Of_Publication AS Label, COUNT(*) AS Value
        FROM books
        WHERE Year_Of_Publication BETWEEN 1900 AND YEAR(GETDATE())
        GROUP BY Year_Of_Publication
        ORDER BY Year_Of_Publication");
            dto.BooksByYear = yearStats.ToList();

            // Kitaplar Tablosu
            var bookTableQuery = @"
    SELECT TOP 5
        b.Book_Title AS BookTitle,
        b.Book_Author AS Author,
        b.Image_URL_L AS ImageUrl,
        b.Year_Of_Publication AS YearOfPublication,
        b.Publisher,
        r.Book_Rating AS Rating
    FROM books b
    INNER JOIN ratings r ON b.ISBN = r.ISBN
    WHERE b.Year_Of_Publication > 0 AND r.Book_Rating > 0
";

            var bookTableData = await connection.QueryAsync<DashboardBookTableDto>(bookTableQuery);
            dto.BookTableItems = bookTableData.ToList();

            return dto;
        }

        public async Task<List<ChartDto>> GetRatingDistributionAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"
            SELECT CAST(Book_Rating AS VARCHAR) AS Label, COUNT(*) AS Value
            FROM ratings
            WHERE Book_Rating BETWEEN 1 AND 10
            GROUP BY Book_Rating
            ORDER BY Book_Rating";

                var result = await connection.QueryAsync<ChartDto>(query);
                return result.ToList();
            }
        }

        

    }
}
