using AuthServices;
using AuthServices.Models;
using MaterialDesignX.Common;
using MaterialDesignX.Services.APIDataType;
using MaterialDesignX.Util;
using MaterialDesignX.ViewModels;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MaterialDesignX.Services
{
    public class CustomerService
    {
        public CustomerService()
        {

        }

        public async Task<BODataProcessResult> Login(LoginRequest request)
        {
            BODataProcessResult result = new BODataProcessResult();
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(AppConstant.BaseAPIUrl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add(AppConstant.APIKeyHeaderName, AppConstant.APIKey);


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
                            IThisoWebLoginResult userInfo = DeserializeExtensions.Deserialize<IThisoWebLoginResult>(strLoginResult);
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

        public async Task<BODataProcessResult> GetProfile(GetProfileRequest request)
        {
            BODataProcessResult result = new BODataProcessResult();
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(AppConstant.BaseAPIUrl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add(AppConstant.APIKeyHeaderName, AppConstant.APIKey);


                string json = JsonSerializer.Serialize(request);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(AppConstant.GetProfileUrl, data);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        BODataProcessResult getProfileResult = DeserializeExtensions.Deserialize<BODataProcessResult>(content);
                        if (getProfileResult.OK)
                        {
                            string strLoginResult = JsonSerializer.Serialize(getProfileResult.Content);
                            IThisoWebCustomerProfileData userInfo = DeserializeExtensions.Deserialize<IThisoWebCustomerProfileData>(strLoginResult);
                            if (userInfo != null)
                            {
                                result.OK = true;
                                result.Message = "Get profile sucessfully";
                                result.Content = userInfo;
                            }
                            else
                            {
                                result.OK = false;
                                result.Message = "Get profile failed";
                            }
                        }
                        else
                        {
                            result.OK = false;
                            result.Message = "Get profile failed";
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

        public async Task<BODataProcessResult> UpdateProfile(UpdateProfileViewModel viewModel)
        {
            BODataProcessResult result = new BODataProcessResult();
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(AppConstant.BaseAPIUrl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add(AppConstant.APIKeyHeaderName, AppConstant.APIKey);

                UpdateProfileRequest request = new UpdateProfileRequest();

                string json = JsonSerializer.Serialize(request);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(AppConstant.UpdateProfileUrl, data);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        BODataProcessResult updateResult = DeserializeExtensions.Deserialize<BODataProcessResult>(content);
                        if (updateResult.OK)
                        {
                            string strLoginResult = JsonSerializer.Serialize(updateResult.Content);
                            UserInfo userInfo = DeserializeExtensions.Deserialize<UserInfo>(strLoginResult);
                            if (userInfo != null)
                            {
                                result.OK = true;
                                result.Message = "Update profile sucessfully";
                                result.Content = userInfo;
                            }
                            else
                            {
                                result.OK = false;
                                result.Message = "Update profile failed";
                            }
                        }
                        else
                        {
                            result.OK = false;
                            result.Message = "Update profile failed";
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
