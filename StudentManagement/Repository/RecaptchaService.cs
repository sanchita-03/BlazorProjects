using System.Text.Json;

namespace StudentManagement.Repository
{
    public class RecaptchaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _secretKey;

        public RecaptchaService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClient = httpClientFactory.CreateClient();
            _secretKey = config["Recaptcha:SecretKey"];
        }

        public async Task<bool> VerifyTokenAsync(string token)
        {
            var response = await _httpClient.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={token}", null);

            if (!response.IsSuccessStatusCode) return false;

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("success").GetBoolean();
        }
    }

}
