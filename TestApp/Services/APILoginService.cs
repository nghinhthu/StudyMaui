using AuthServices;
using AuthServices.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TestApp.Common;
using TestApp.Util;

namespace TestApp.Services
{
    public class APILoginService
    {

        public APILoginService()
        {

        }

        public async Task<BODataProcessResult> Login(string userName, string password)
        {
            BODataProcessResult result = new BODataProcessResult();
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(AppConstant.BaseAPIUrl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                LoginModel request = new LoginModel();
                request.UserName = userName;
                request.Password = password;
                request.CompanyID = 3;
                request.AppID = 3;
                request.UserType = "UserID";
                request.KeepLogined = true;

                string json = JsonSerializer.Serialize(request);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(AppConstant.LoginUrl, data);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        BODataProcessResult loginResult = DeserializeExtensions.Deserialize<BODataProcessResult>(content);
                        if (loginResult.OK)
                        {
                            string strLoginResult = JsonSerializer.Serialize(loginResult.Content);
                            UserInfo userInfo = DeserializeExtensions.Deserialize<UserInfo>(strLoginResult);
                            if (userInfo != null)
                            {
                                result.OK = true;
                                result.Message = "Login sucessfully";
                                result.Content = userInfo;
                            }
                            else
                            {
                                result.OK = false;
                                result.Message = "Login failed";
                            }
                        }
                        else
                        {
                            result.OK = false;
                            result.Message = "Login failed";
                        }
                    }
                }
                else
                {
                    result.Message = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                throw;
            }
            return result;
        }
    }
}
