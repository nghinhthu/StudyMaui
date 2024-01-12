using AuthServices;
using TestApp.Services;

namespace TestApp.Helper.Logic
{
    public class LoginViewModelHelper
    {
        APILoginService _loginService;
        public LoginViewModelHelper(APILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<BODataProcessResult> Login(string userName, string password)
        {
            BODataProcessResult result = await _loginService.Login(userName, password);
            return result;
        }
    }
}
