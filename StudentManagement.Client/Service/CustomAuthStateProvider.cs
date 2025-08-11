using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace StudentManagement.Client.Service
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;

            // Minimal validation settings for demonstration (you can expand this)
            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = false,
                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    var handler = new JsonWebTokenHandler();
                    return handler.ReadJsonWebToken(token);
                }
            };
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var identity = new ClaimsIdentity();

            if (!string.IsNullOrWhiteSpace(token))
            {
                var handler = new JsonWebTokenHandler();
                var result = handler.ValidateToken(token, _tokenValidationParameters);

                if (result.IsValid)
                {
                    var jwtToken = result.SecurityToken as JsonWebToken;
                    identity = new ClaimsIdentity(jwtToken?.Claims, "jwt");
                }
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public void NotifyUserAuthentication(string token)
        {
            var handler = new JsonWebTokenHandler();
            var result = handler.ValidateToken(token, _tokenValidationParameters);

            if (result.IsValid)
            {
                var jwtToken = result.SecurityToken as JsonWebToken;
                var identity = new ClaimsIdentity(jwtToken?.Claims, "jwt");
                var user = new ClaimsPrincipal(identity);
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            }
        }

        public void NotifyUserLogout()
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}
