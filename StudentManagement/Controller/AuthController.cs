using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Repository;
using StudentManagement.Shared.Model;

namespace StudentManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private readonly RecaptchaService _recaptchaService;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration config, RecaptchaService recaptchaService)
        {
            _userManager = userManager;
            _config = config;
            _recaptchaService = recaptchaService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // ✅ Step 1: Verify CAPTCHA
            var captchaValid = await _recaptchaService.VerifyTokenAsync(request.CaptchaToken);
            if (!captchaValid)
                return Unauthorized(new AuthResponse { IsSuccess = false, Message = "Captcha validation failed." });

            // ✅ Step 2: Validate user credentials
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var token = GenerateJwtToken(user);
                return Ok(new AuthResponse { IsSuccess = true, Token = token });
            }

            return Unauthorized(new AuthResponse { IsSuccess = false, Message = "Invalid credentials" });
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
