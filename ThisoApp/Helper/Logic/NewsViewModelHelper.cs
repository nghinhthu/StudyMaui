using AuthServices;
using ThisoApp.Services;
using ThisoApp.Services.APIDataType;
using ThisoApp.ViewModels;

namespace ThisoApp.Helper.Logic
{
    public class NewsViewModelHelper
    {
        public NewsViewModelHelper()
        {

        }

        public async Task<List<NewsData>> GetNews(string catNumber = "PROMOTION")
        {
            ThisoWebNewsPromotionRequest request = new ThisoWebNewsPromotionRequest();
            NewsService newsService = new NewsService();
            BODataProcessResult result = await newsService.GetNews(request);
            if (result.OK && result.Content != null)
            {
                List<ThisoNewsData> thisoNewsDatas = (List<ThisoNewsData>)result.Content;
                thisoNewsDatas = thisoNewsDatas.Where(x => x.CatNumber == catNumber && x.LangCode.ToUpper() == "VN").OrderByDescending(x => x.CreatedOn).Take(10).ToList();
                List<NewsData> newsDatas = new List<NewsData>();
                foreach (var item in thisoNewsDatas)
                {
                    NewsData newsData = new NewsData()
                    {
                        ID = item.Id,
                        Number = item.Number,
                        Subject = item.Subject,
                        Description = item.Description,
                        Content = item.NewsContent,
                        CatNumber = item.CatNumber
                    };
                    newsDatas.Add(newsData);
                }
                return newsDatas;
            }
            else
            {
                return null;
            }
        }
    }
}
