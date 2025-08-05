namespace _09PC_Dapper.Dtos.RatingDtos
{
    public class CreateRatingDto
    {
        public int User_ID { get; set; }
        public string ISBN { get; set; }
        public int Book_Rating { get; set; }
    }
}
