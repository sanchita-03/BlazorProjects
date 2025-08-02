using System.Text.Json;
using System.Net.Http;

namespace StudentManagement.Client.Service
{
    public class RecaptchaService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public RecaptchaService(IConfiguration config, IHttpClientFactory factory)
        {
            _config = config;
            _httpClient = factory.CreateClient();
        }

        public async Task<bool> VerifyTokenAsync(string token)
        {
            var secret = _config["Recaptcha:SecretKey"];
            var response = await _httpClient.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={token}", null);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RecaptchaVerifyResponse>(json);

            return result?.Success ?? false;
        }

        private class RecaptchaVerifyResponse
        {
            public bool Success { get; set; }
            public List<string> ErrorCodes { get; set; }
        }
    }
}
