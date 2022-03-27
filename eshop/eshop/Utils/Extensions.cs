using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Utils
{
    public static class Extensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static bool IsValidSize(this IFormFile file, int kb)
        {
            return file.Length / 1024 < kb;
        }

        public async static Task<string> Upload(this IFormFile file, string root, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
            string finalPath = Path.Combine(root, folder, fileName);
            FileStream fileStream = new FileStream(finalPath, FileMode.Create);

            await file.CopyToAsync(fileStream);

            return fileName;
        }

        public static bool ImagesAreValid(this IFormFile[] files)
        {
            foreach (IFormFile item in files)
            {
                if (!item.IsImage())
                {
                    return false;
                }
                if (!item.IsValidSize(500))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
