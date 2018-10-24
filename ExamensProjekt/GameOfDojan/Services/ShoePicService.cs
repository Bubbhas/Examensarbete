using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                newFilePath = GetNewFilePath(formFile.FileName);
                filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            File.Copy(filePath, newFilePath);
            return newFilePath;
        }

        public string GetNewFilePath(string formFile)
        {
            if (formFile == null)
            {
                throw new ArgumentException();
            }
            string randomFileName = Path.GetRandomFileName();
            string newFilePath = "";
            if (formFile.ToLower().EndsWith(".jpg"))
            {
                newFilePath = $@"wwwroot\Pics\{randomFileName}.jpg";
            }
            else if (formFile.ToLower().EndsWith(".png"))
            {
             newFilePath = $@"wwwroot\Pics\{randomFileName}.png";
            }
            else
            {
                 throw new ArgumentException();
            }
            return newFilePath;
        }
    }
}
