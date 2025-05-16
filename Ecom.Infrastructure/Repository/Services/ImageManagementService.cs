using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Ecom.Infrastructure.Repository.Services
{
    public class ImageManagementService : IImageManagmentService
    {
        private readonly IFileProvider fileprovider;

        public ImageManagementService(IFileProvider fileprovider)
        {
            this.fileprovider = fileprovider;
        }
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            List<string> saveImageSrc = new List<string>();
            var ImageDirectory = Path.Combine("wwwroot","Images", src);
            if(!Directory.Exists(ImageDirectory))
            {
                Directory.CreateDirectory(ImageDirectory);
            }
            foreach(var item in files)
            {
                if(item.Length > 0)
                {
                    //var fileName = Path.GetFileName(item.FileName);
                    //var filePath = Path.Combine(ImgDirectory, fileName);
                    //using (var stream = new FileStream(filePath, FileMode.Create))
                    //{
                    //    item.CopyTo(stream);
                    //}
                    //saveImageSrc.Add(Path.Combine("Images", src, fileName));
                    var ImageName = item.FileName;
                    var ImageSrc = $"/Images/{src}/{ImageName}";
                    var root = Path.Combine(ImageDirectory,ImageName);
                    using FileStream stream = new FileStream(root, FileMode.Create);
                    {
                        await item.CopyToAsync(stream);
                        saveImageSrc.Add(ImageSrc);
                    }
                }
            }
            return saveImageSrc;
        }

        public void DeleteImageAsync(string src)
        {
            var info = fileprovider.GetFileInfo(src);
            var root = info.PhysicalPath;
            File.Delete(root);
        }
    }
}
