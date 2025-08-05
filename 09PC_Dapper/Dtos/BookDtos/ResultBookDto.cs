namespace _09PC_Dapper.Dtos.BookDtos
{
    public class ResultBookDto
    {
        public string ISBN { get; set; }
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
        public int Year_Of_Publication { get; set; }
        public string Publisher { get; set; }
        public string Image_URL_S { get; set; }
        public string Image_URL_M { get; set; }
        public string Image_URL_L { get; set; }
    }
}
