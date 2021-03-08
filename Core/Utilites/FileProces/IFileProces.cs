using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilites.Results.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.Utilites.FileProces
{
    public interface IFileProcess
    {
        /// <summary>
        /// Create File
        /// </summary>
        /// <param name="directoryPath">example 1: foldername <br></br> example 2: foldername/subfoldername/.... [unlimited]</param>
        /// <param name="file">IFromFile type</param>
        /// <returns>IDataResult.Data = Path of the file created.</returns>
        IDataResult<string> Upload(string directoryPath, IFormFile file);

        /// <summary>
        /// Delete File
        /// </summary>
        /// <param name="filePath">example 1: "foldername/filename" </param>
        /// <returns></returns>
        IResult Delete(string filePath);
    }
}
