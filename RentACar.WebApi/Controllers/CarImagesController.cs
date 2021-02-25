using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebApi.Controllers
{
    /// <summary>
    /// General Car Images Manager 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private IFileProcess fileProcess;
        private ICarImageService carImageService;

        public CarImagesController(IFileProcess fileProcess, ICarImageService carImageService)
        {
            this.fileProcess = fileProcess;
            this.carImageService = carImageService;
        }

        [HttpPost]
        [Route("add/{id}")]
        public IActionResult UploadImage([FromForm] IFormFile files, int id)
        {
            var result = carImageService.Add(id,files);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteCarImage(int id,string path)
        {
            var result = carImageService.Delete(id);
            if (result == null)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
