using _09PC_Dapper.Dtos.BookDtos;
using _09PC_Dapper.Dtos.DepartmentDtos;

namespace _09PC_Dapper.Services.BookServices
{
    public interface IBookService
    {
        Task<List<ResultBookDto>> GetAllBooksAsync();
        Task CreateBookAsync(CreateBookDto createBookDto);
        Task UpdateBookAsync(UpdateBookDto updateBookDto);
        Task DeleteBookAsync(string isbn);
        Task<GetBookByIdDto> GetBookByIdAsync(string isbn);
        Task<(List<ResultBookDto> Books, int TotalCount)> GetBooksPagedAsync(int page, int pageSize, string search);
        Task<List<BookWithRatingDto>> GetBooksWithRatingsAsync(int page = 1, int pageSize = 9);

    }
}
