using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    /// <summary>
    /// General file manager interface
    /// </summary>
    public interface IFileProcess
    {
        public Task<IResult> Upload(string fileName, IFormFile fileList);
        public IResult Delete(string path);
    }
}
