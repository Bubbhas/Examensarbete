using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GameOfDojan.Services
{
    public interface IShoePicService
    {
        Task<string> AddPicToFolder(List<IFormFile> files);
    }
}