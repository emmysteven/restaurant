using Microsoft.AspNetCore.Http;

namespace Restaurant.Application.Common.Interfaces
{
    public interface IFileUploadService
    {
        public string UploadFile(IFormFile file);
    }
}