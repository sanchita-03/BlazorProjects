using Microsoft.AspNetCore.Mvc;
using StudentManagement.Repository;
using StudentManagement.Shared.Model;

namespace StudentManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageCaptchaController : ControllerBase
    {
        private readonly ImageCaptchaGenerator _captchaGenerator;
        private const string CaptchaSessionKey = "CaptchaCode";

        public ImageCaptchaController(ImageCaptchaGenerator captchaGenerator)
        {
            _captchaGenerator = captchaGenerator;
        }

        // GET: api/captcha/image
        [HttpGet("image")]
        public IActionResult GetCaptchaImage()
        {
            var captchaCode = _captchaGenerator.GenerateRandomCode();
            HttpContext.Session.SetString(CaptchaSessionKey, captchaCode);

            var imageBytes = _captchaGenerator.GenerateCaptchaImage(captchaCode);
            return File(imageBytes, "image/png");
        }

        // POST: api/captcha/verify
        [HttpPost("verify")]
        public IActionResult VerifyCaptcha([FromBody] CaptchaVerifyRequest request)
        {
            var storedCode = HttpContext.Session.GetString(CaptchaSessionKey);

            if (string.IsNullOrWhiteSpace(storedCode))
                return BadRequest("Captcha code not found. Please reload the image.");

            if (string.Equals(request.InputCode, storedCode, StringComparison.OrdinalIgnoreCase))
            {
                return Ok(new { success = true, message = "Captcha verified successfully." });
            }

            return BadRequest(new { success = false, message = "Invalid captcha code." });
        }
    }

}

