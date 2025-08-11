using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentManagement.Client.Service;

using Microsoft.AspNetCore.Components.Authorization;

namespace StudentManagement.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<CustomAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
                provider.GetRequiredService<CustomAuthStateProvider>());
            builder.Services.AddScoped<StudentService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<RecaptchaService>();
            builder.Services.AddScoped<ImageCaptchaService>();
           

            await builder.Build().RunAsync();
        }
    }
}
