namespace _09PC_Dapper.Dtos.BookDtos
{
    public class BookWithRatingDto
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public int YearOfPublication { get; set; }
        public string Publisher { get; set; }
        public double Rating { get; set; }
    }
}
