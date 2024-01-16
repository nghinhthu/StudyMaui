using System.Collections.ObjectModel;
using ThisoApp.Helper.Logic;
using ThisoApp.ViewModels;

namespace ThisoApp.Views;

public partial class NewsPage : ContentPage
{
    NewsViewModel viewModel;
    public NewsPage(NewsViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetNews();
        this.BindingContext = viewModel;
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            //string previous = (e.PreviousSelection.FirstOrDefault() as CategoryData)?.Number;
            string current = (e.CurrentSelection.FirstOrDefault() as CategoryData)?.Number;

            NewsViewModelHelper newsViewModelHelper = new NewsViewModelHelper();
            List<NewsData> listNewsData = newsViewModelHelper.GetNews(current).Result;
            NewsViewModel viewModel = new NewsViewModel();
            ObservableCollection<NewsData> collectionNewsData = new ObservableCollection<NewsData>();
            foreach (var item in listNewsData)
            {
                collectionNewsData.Add(item);
            }

            this.viewModel.News = collectionNewsData;

        }
        catch (Exception ex)
        {

        }
    }
}