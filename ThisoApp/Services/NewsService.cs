using AuthServices;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ThisoApp.Common;
using ThisoApp.Services.APIDataType;
using ThisoApp.Util;

namespace ThisoApp.Services
{
    public class NewsService
    {
        public NewsService()
        {

        }

        public async Task<BODataProcessResult> GetNews(ThisoWebNewsPromotionRequest request)
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
                HttpResponseMessage response = await httpClient.PostAsync(AppConstant.GetNewsUrl, data);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        BODataProcessResult processResult = DeserializeExtensions.Deserialize<BODataProcessResult>(content);
                        if (processResult.OK)
                        {
                            string strProcessResult = JsonSerializer.Serialize(processResult.Content);
                            List<ThisoNewsData> newsDatas = DeserializeExtensions.Deserialize<List<ThisoNewsData>>(strProcessResult);
                            if (newsDatas != null && newsDatas.Count > 0)
                            {
                                result.OK = true;
                                result.Message = "Get news sucessfully";
                                result.Content = newsDatas;
                            }
                            else
                            {
                                result.OK = false;
                                result.Message = "Get news failed";
                            }
                        }
                        else
                        {
                            result.OK = false;
                            result.Message = "Get news failed";
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
