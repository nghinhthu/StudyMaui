using AuthServices;
using ThisoApp.Common;
using ThisoApp.Services;
using ThisoApp.Services.APIDataType;
using ThisoApp.ViewModels;

namespace ThisoApp.Helper.Logic
{
    public class CustomerViewModelHelper
    {
        //CustomerServsice _customerService;
        //public CustomerViewModelHelper(CustomerService customerService)
        //{
        //    _customerService = _customerService;
        //}

        public CustomerViewModelHelper()
        {

        }

        public async Task<LoginViewModel> LoginHelper(LoginViewModel viewModel)
        {
            LoginRequest request = new LoginRequest();
            request.Language = "Vn";
            request.AccountType = "Mobile";
            request.AppName = AppConstant.AppName;
            request.UserID = viewModel.UserName;
            request.Pwd = viewModel.Password;


            CustomerService customerService = new CustomerService();
            BODataProcessResult result = await customerService.Login(request);
            if (result != null && result.OK)
            {
                IThisoWebLoginResult loginResult = (IThisoWebLoginResult)result.Content;
                Preferences.Set("MemID", loginResult.MemID);
                Preferences.Set("SessionID", loginResult.SessionID);
                return new LoginViewModel();
            }
            else
            {
                return null;
            }
        }

        public async Task<UpdateProfileViewModel> GetProfileHelper()
        {
            UpdateProfileViewModel viewModel = new UpdateProfileViewModel();
            GetProfileRequest request = new GetProfileRequest();
            request.AppName = AppConstant.AppName;
            request.Language = "Vn";
            request.MemID = Preferences.Get("MemID", "");
            request.SessionID = Preferences.Get("SessionID", "");
            CustomerService customerService = new CustomerService();
            BODataProcessResult result = await customerService.GetProfile(request);
            if (result.OK)
            {
                IThisoWebCustomerProfileData profileData = (IThisoWebCustomerProfileData)result.Content;
                viewModel.FullName = profileData.FullName;
                viewModel.Email = profileData.Email;
                viewModel.Mobile = profileData.Mobile;
                viewModel.IDCardNo = profileData.IDNo;
                viewModel.Gender = (int)profileData.Gender;
                viewModel.DOB = (DateTime)profileData.DOB;
                viewModel.District = profileData.DistrictID;
                viewModel.Province = profileData.ProvinceID;
                viewModel.Address = profileData.ShortAddress;
                return viewModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<BODataProcessResult> UpdateProfile(UpdateProfileViewModel viewModel)
        {
            CustomerService customerService = new CustomerService();
            UpdateProfileRequest request = new UpdateProfileRequest();
            request.AppName = AppConstant.AppName;
            request.Language = "Vn";
            request.SessionID = Preferences.Get("SessionID", "");
            request.CustomerProfile = new CustomerProfile()
            {
                MemID = Preferences.Get("MemID", ""),
                FullName = viewModel.FullName,
                Mobile = viewModel.Mobile,
                Email = viewModel.Email,
                IdNo = viewModel.IDCardNo,
                Dob = viewModel.DOB,
                Gender = viewModel.Gender,
                ProvinceID = 50,
                DistrictID = 1,
                ShortAddress = viewModel.Address
            };
            BODataProcessResult result = await customerService.UpdateProfile(request);
            return result;
        }
    }
}
