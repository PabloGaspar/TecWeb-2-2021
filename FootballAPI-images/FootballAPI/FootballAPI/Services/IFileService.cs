using Microsoft.AspNetCore.Http;

namespace FootballAPI.Services
{
    public interface IFileService
    {
        string UploadFile(IFormFile file);
    }
}
