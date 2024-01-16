namespace ThisoApp.ViewModels
{
    public class NewsData
    {
        public NewsData()
        {
            ImageUrl = "https://thisomallsala.vn:441/Resource/Images/News/PR00219/Images/PR00219_400_400.webp";
        }

        public int ID { get; set; }
        public string Number { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string CatNumber { get; set; }
    }
}
