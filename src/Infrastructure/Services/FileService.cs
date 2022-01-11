using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Restaurant.Application.Common.Interfaces;

namespace Restaurant.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _env;
    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public string UploadFile(IFormFile file)
    {
        string imageName = new String(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
        imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
        var imagePath = Path.Combine(_env.WebRootPath, "images", imageName);
        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        {
            file.CopyToAsync(fileStream);
        }
        return imageName;
    }
}