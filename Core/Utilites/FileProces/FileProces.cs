using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Core.Utilites.FileProces
{
    public class FileProcess : IFileProcess
    {
        private readonly IHostingEnvironment environment;

        public FileProcess(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public IResult Delete(string filePath)
        {
            File.Delete(filePath);
            return new SuccessResult();
        }

        public IDataResult<string> Upload(string directoryPath, IFormFile file)
        {
            FolderControl(directoryPath);
            if (file != null && file.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString("D") + Path.GetExtension(file.FileName).ToLower();
                var filePath = Path.Combine(environment.WebRootPath, directoryPath, fileName);
                using (var stream = File.Create(filePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                return new SuccessDataResult<string>(Path.Combine(directoryPath, fileName), "");
            }
            return new ErrorDataResult<string>();
        }

        /// <summary>
        /// FolderControl
        /// </summary>
        /// <param name="directoryPath">example 1: foldername <br></br> example 2: foldername/subfoldername/.... [unlimited]</param>
        private void FolderControl(string directoryPath)
        {
            string[] directories = directoryPath.Split('/');
            string checkPath = "";

            foreach (var directory in directories)
            {
                checkPath += directory + "\\";
                var path = Path.Combine(environment.WebRootPath, checkPath);
                if (!Directory.Exists(checkPath))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
