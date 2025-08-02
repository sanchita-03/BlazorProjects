using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using StudentManagement.Shared.Model;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;

namespace StudentManagement.Client.Service
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public AuthService(HttpClient http, ILocalStorageService localStorage,NavigationManager navigationManager)
        {
            _http = http;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", request);

            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                if (authResponse != null && authResponse.IsSuccess)
                {
                    // ✅ Store JWT token
                    await _localStorage.SetItemAsync("authToken", authResponse.Token);

                    // ✅ Set default Authorization header
                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authResponse.Token);

                    return true;
                }
            }
            return false;
        }

        public void Logout()
        {
            // Remove token from local storage
            _localStorage.RemoveItemAsync("authToken");

            // Redirect to login page
            _navigationManager.NavigateTo("/login");
        }
    }
}
