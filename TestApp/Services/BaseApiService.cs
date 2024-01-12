using AuthServices;
using System.Text;
using System.Text.Json;

namespace TestApp.Services
{
    public class BaseApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected JsonSerializerOptions DefaultSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public BaseApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected TData Deserialize<TData>(string jsonData)
        {
            return JsonSerializer.Deserialize<TData>(jsonData, DefaultSerializerOptions);
        }

        protected async Task<TData> HandleApiResponseAsync<TData>(HttpResponseMessage response, TData defaultValue)
        {
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    return Deserialize<TData>(content);
                }
            }

            return defaultValue;
        }

        protected async Task<HttpResponseMessage> PostRequest(object request, string strApiUrl, string serviceName)
        {
            HttpClient HttpClient = _httpClientFactory.CreateClient(serviceName);
            string json = JsonSerializer.Serialize(request);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            return await HttpClient.PostAsync(strApiUrl, data);
        }

        protected async Task<BODataProcessResult> PostRequest(object request, string strApiUrl, string serviceName, BODataProcessResult defaultValue)
        {
            HttpClient HttpClient = _httpClientFactory.CreateClient(serviceName);
            string json = JsonSerializer.Serialize(request);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpClient.PostAsync(strApiUrl, data);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    return Deserialize<BODataProcessResult>(content);
                }
            }

            return defaultValue;
        }

        protected async Task<HttpResponseMessage> GetRequest(string strApiUrl, string serviceName)
        {
            HttpClient HttpClient = _httpClientFactory.CreateClient(serviceName);
            return await HttpClient.GetAsync(strApiUrl);
        }
    }
}
