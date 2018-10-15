using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Services
{
    public class ShoePicService : IShoePicService
    {
        public async Task<string> AddPicToFolder(List<IFormFile> files)
        {
            string newFilePath = @"C:\Users\Administrator\Desktop\examen\GameOfDojan\wwwroot\Pics\a.jpg";
            var filePath = Path.GetTempFileName();
            foreach (var formFile in files)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            File.Copy(filePath, newFilePath);
            return newFilePath;
        }
    }
}
