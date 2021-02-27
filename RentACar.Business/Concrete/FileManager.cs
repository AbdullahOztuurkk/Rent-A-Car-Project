using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Concrete
{
    /// <summary>
    /// General File Manager for storing Images
    /// </summary>
    public class FileManager:IFileProcess
    {
        private readonly IHostingEnvironment environment;
        string FileDirectory;

        public FileManager(IHostingEnvironment environment)
        {
            this.environment = environment;
            FileDirectory = environment.ContentRootPath + "/images/";
        }
        /// <summary>
        /// Upload to server's assets folder
        /// </summary>
        /// <param name="fileName">Guid File Name</param>
        /// <param name="file">Image</param>
        /// <returns></returns>
        public async Task<IResult> Upload(string fileName, IFormFile file)
        {
            using (var fileStream = new FileStream(Path.Combine(FileDirectory, fileName.ToString() + ".png"), FileMode.Create, FileAccess.Write))
            {
                 await file.CopyToAsync(fileStream);
            }
            return new SuccessResult(Messages.Add_Message(typeof(CarImage).Name));
        }
        /// <summary>
        /// Delete file from given path
        /// </summary>
        /// <param name="path">Guid file path</param>
        /// <returns></returns>
        public IResult Delete(string path)
        {
            var roadpath = Path.Combine(FileDirectory, path+ ".png");
            if (File.Exists(roadpath))
            {
                File.Delete(roadpath);
            }
            return new SuccessResult();
        }
    }
}
