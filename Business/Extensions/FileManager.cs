﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using System;


namespace Business.Extensions
{
    public static class FileManager
    {

        public static string CreateImage(this IFormFile file, IWebHostEnvironment env, params string[] folders)
        {
            string oldFileName = file.FileName;
            string fileExtention = oldFileName.Split('.').Last();

            string fileName = $"{Guid.NewGuid()}_{DateTime.Now.ToString("yyyyMMddHHmmssffff")}.{fileExtention}";

            string path = env.WebRootPath;

            foreach (string folder in folders)
            {
                path = Path.Combine(path, folder);
            }

            path = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }

        public static bool CheckFileSize(this IFormFile file, double size)
        {
            return Math.Round((double)file.Length / 1024) < size;
        }

        public static bool CheckFileType(this IFormFile file, string contentType)
        {
            return file.ContentType == contentType;
        }

    }
}
