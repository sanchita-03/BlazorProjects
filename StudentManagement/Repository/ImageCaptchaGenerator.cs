using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using System;
using System.IO;
using System.Linq;

namespace StudentManagement.Repository
{
    public class ImageCaptchaGenerator
    {
        private readonly FontFamily _defaultFontFamily;
        private const string CaptchaSessionKey = "CaptchaCode";

        public ImageCaptchaGenerator()
        {
            var fontCollection = new FontCollection();

            // Load Arial or fallback to system default font if not found.
            if (SystemFonts.TryGet("Arial", out FontFamily family))
            {
                _defaultFontFamily = family;
            }
            else
            {
                _defaultFontFamily = SystemFonts.Families.First(); // Use any available font
            }
        }

        public byte[] GenerateCaptchaImage(string captchaCode, int width = 200, int height = 60)
        {
            var font = _defaultFontFamily.CreateFont(36, FontStyle.Bold);

            using (var image = new Image<Rgba32>(width, height))
            {
                image.Mutate(ctx =>
                {
                    // Fill background
                    ctx.Fill(Color.White);

                    // Draw text
                    ctx.DrawText(captchaCode, font, Color.Black, new PointF(20, 10));

                    // Add random lines for noise
                    var rand = new Random();
                    for (int i = 0; i < 3; i++)
                    {
                        var start = new PointF(rand.Next(width), rand.Next(height));
                        var end = new PointF(rand.Next(width), rand.Next(height));

                        var pathBuilder = new SixLabors.ImageSharp.Drawing.PathBuilder();
                        pathBuilder.StartFigure();
                        pathBuilder.AddLine(start, end);
                        var path = pathBuilder.Build();

                        ctx.Draw(Color.Gray, 1, path);
                    }
                });

                using var ms = new MemoryStream();
                image.SaveAsPng(ms);
                return ms.ToArray();
            }
        }

        public string GenerateRandomCode(int length = 5)
        {
            var chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var rand = new Random();
            return new string(Enumerable.Range(0, length)
                .Select(_ => chars[rand.Next(chars.Length)]).ToArray());
        }

        

        public string GetStoredCaptchaCode(HttpContext httpContext)
        {
            return httpContext.Session.GetString(CaptchaSessionKey);
        }

        public  bool VerifyCaptchaCode(HttpContext httpContext,string userInput)
        {
            string storedCode = GetStoredCaptchaCode(httpContext);
            if (string.IsNullOrWhiteSpace(storedCode))
                return false;

            return string.Equals(userInput, storedCode, StringComparison.OrdinalIgnoreCase);
        }
    }
}
