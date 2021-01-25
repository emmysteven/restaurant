using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Restaurant.Application.Common.Interfaces;

namespace Restaurant.Infrastructure.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        public FileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string UploadFile(IFormFile file)
        {
            var folderPath = Path.Combine(_environment.WebRootPath, "images");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, file.FileName);

            using var fs = File.Create(filePath);
            file.CopyTo(fs);
            return filePath;
        }

    }
}