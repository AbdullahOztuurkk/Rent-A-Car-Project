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
        [Route("image/{id}")]
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

        [HttpGet]
        [Route("detail")]
        public IActionResult GetCarDetailList()
        {
            var result = carService.GetCarDetails();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("detail/color/{id}")]
        public IActionResult GetCarDetailListByColorId(int colorId)
        {
            var result = carService.GetCarDetailsByColorId(colorId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("detail/brand/{id}")]
        public IActionResult GetCarDetailListByBrandId(int brandId)
        {
            var result = carService.GetCarDetailsByBrandId(brandId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("detail/{id}")]
        public IActionResult GetCarDetailByCarId(int carId)
        {
            var result = carService.GetCarDetailsByCarId(carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("brand/{id}")]
        public IActionResult GetAllByBrandId(int id)
        {
            var result = carService.GetByBrandId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        [HttpGet]
        [Route("color/{id}")]
        public IActionResult GetAllByColorId(int id)
        {
            var result = carService.GetByColorId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
