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
            string newFilePath = "";
            var filePath = "";
            foreach (var formFile in files)
            {
                newFilePath = GetNewFilePath(formFile);
                filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            File.Copy(filePath, newFilePath);
            return newFilePath;
        }

        private string GetNewFilePath(IFormFile formFile)
        {
            string randomFileName = Path.GetRandomFileName();
            string newFilePath = "";
            if (formFile.FileName.ToLower().EndsWith("jpg"))
            {
                newFilePath = $@"C:\Users\Administrator\Desktop\examen\GameOfDojan\wwwroot\Pics\{randomFileName}.jpg";
            }
            else if (formFile.FileName.ToLower().EndsWith("png"))
            {
                newFilePath = $@"C:\Users\Administrator\Desktop\examen\GameOfDojan\wwwroot\Pics\{randomFileName}.png";
            }
            else
            {
                return BadImageFormatException();
            }
            return newFilePath;
        }
    }
}
