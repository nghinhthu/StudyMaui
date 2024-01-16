using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ThisoApp.Helper.Logic;

namespace ThisoApp.ViewModels
{
    public partial class NewsViewModel : ObservableObject
    {
        public NewsViewModel()
        {
            Categories = InitCateData();
        }
        [ObservableProperty]
        private ObservableCollection<CategoryData> categories;

        [ObservableProperty]
        private ObservableCollection<NewsData> news;


        private ObservableCollection<CategoryData> InitCateData()
        {
            ObservableCollection<CategoryData> datas = new ObservableCollection<CategoryData>();
            CategoryData newsCat = new CategoryData()
            {
                ID = 1,
                Name = "Promotion",
                Number = "PROMOTION"
            };
            datas.Add(newsCat);
            CategoryData eventCat = new CategoryData()
            {
                ID = 2,
                Name = "Event",
                Number = "EVENT"
            };
            datas.Add(eventCat);
            CategoryData aboutCat = new CategoryData()
            {
                ID = 2,
                Name = "About",
                Number = "ABOUT"
            };
            datas.Add(aboutCat);
            return datas;
        }

        public async Task GetNews()
        {
            NewsViewModelHelper newsViewModelHelper = new NewsViewModelHelper();
            List<NewsData> listNewsData = await newsViewModelHelper.GetNews();
            NewsViewModel viewModel = new NewsViewModel();
            ObservableCollection<NewsData> collectionNewsData = new ObservableCollection<NewsData>();
            foreach (var item in listNewsData)
            {
                collectionNewsData.Add(item);
            }

            News = collectionNewsData;
            Categories = InitCateData();
        }
    }
}
