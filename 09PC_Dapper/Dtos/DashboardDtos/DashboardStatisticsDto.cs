namespace _09PC_Dapper.Dtos.DashboardDtos
{
    public class DashboardStatisticsDto
    {
        public int TotalBookCount { get; set; }

        public string MaxRatedBookTitle { get; set; }
        public double MaxRating { get; set; }

        public string MinRatedBookTitle { get; set; }
        public double MinRating { get; set; }

        public double AverageUserAge { get; set; }

        public int TotalUserCount { get; set; }
        public int BooksPublishedAfter2000 { get; set; }

        // Grafik için eklenen property'ler
        public List<ChartDto> PublisherBookCounts { get; set; }
        public List<ChartDto> YearlyBookPublications { get; set; }
        public List<ChartDto> RatingDistribution { get; set; } = new List<ChartDto>();
        public List<ChartDto> Top10BooksAverageRating { get; set; }

        public List<ChartDto> BooksByPublisher { get; set; }
        public List<ChartDto> BooksByYear { get; set; }

        public List<DashboardBookTableDto> BookTableItems { get; set; } = new List<DashboardBookTableDto>();
    }

    public class ChartDto
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public double? DoubleValue { get; set; }
    }

    public class DashboardBookTableDto
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public int YearOfPublication { get; set; }
        public string Publisher { get; set; }
        public double Rating { get; set; }
    }
}
