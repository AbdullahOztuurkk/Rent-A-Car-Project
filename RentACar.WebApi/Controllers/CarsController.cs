using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebApi.Controllers
{
    /// <summary>
    /// Api controller for cars
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService carService;
        private ICarImageService carImageService;
        private IFileProcess fileProcess;

        public CarsController(ICarService carService, ICarImageService carImageService, IFileProcess fileProcess)
        {
            this.carService = carService;
            this.carImageService = carImageService;
            this.fileProcess = fileProcess;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = carService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = carService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("images/{id}")]
        public IActionResult GetImages(int id)
        {
            var result = carService.GetAllImagesById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] Car car)
        {
            var result = carService.Add(car);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = carService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Car car)
        {
            var result = carService.Update(car);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
