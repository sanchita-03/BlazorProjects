using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace StudentManagement.Client.Service
{
    public class ImageCaptchaService
    {
        private readonly HttpClient _http;

        public ImageCaptchaService(HttpClient http)
        {
            _http = http;
        }

        /// <summary>
        /// Fetches the captcha image as a byte array.
        /// </summary>
        public async Task<byte[]> GetCaptchaImageAsync()
        {
            return await _http.GetByteArrayAsync("api/imagecaptcha/image");
        }

        /// <summary>
        /// Sends user input to verify captcha.
        /// </summary>
        public async Task<bool> VerifyCaptchaAsync(string inputCode)
        {
            var response = await _http.PostAsJsonAsync("api/imagecaptcha/verify", new
            {
                InputCode = inputCode
            });

            return response.IsSuccessStatusCode;
        }
    }
}
