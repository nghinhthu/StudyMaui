using AuthServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ThisoApp.Helper.Logic;

namespace ThisoApp.ViewModels
{
    public partial class UpdateProfileViewModel : ObservableObject
    {
        private CustomerViewModelHelper _viewModelHelper;
        public UpdateProfileViewModel()
        {

        }
        public UpdateProfileViewModel(CustomerViewModelHelper viewModelHelper)
        {
            _viewModelHelper = viewModelHelper;
        }
        [ObservableProperty]
        private string _fullName;
        [ObservableProperty]
        private string _mobile;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _iDCardNo;
        [ObservableProperty]
        private int _gender;
        [ObservableProperty]
        private DateTime _dOB;
        [ObservableProperty]
        private int _province;
        [ObservableProperty]
        private int _district;
        [ObservableProperty]
        private string _address;
        public string Message { get; set; }

        [RelayCommand]
        async Task UpdateProfile()
        {
            var viewModel = this;
            BODataProcessResult result = await _viewModelHelper.UpdateProfile(viewModel);
            Shell.Current.DisplayAlert("Message", result.Message, "OK");
        }

        public async Task GetProfile()
        {
            UpdateProfileViewModel viewModel = await _viewModelHelper.GetProfileHelper();

            if (viewModel != null)
            {
                this.FullName = viewModel.FullName;
                this.Mobile = viewModel.Mobile;
                this.Email = viewModel.Email;
                this.IDCardNo = viewModel.IDCardNo;
                this.Gender = viewModel.Gender;
                this.DOB = viewModel.DOB;
                this.Province = viewModel.Province;
                this.District = viewModel.District;
                this.Address = viewModel.Address;
            }


        }


    }
}
