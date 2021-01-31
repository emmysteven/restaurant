using Microsoft.AspNetCore.Http;

namespace Restaurant.Application.Common.Interfaces
{
    public interface IFileService
    {
        public string UploadFile(IFormFile file);
    }
}