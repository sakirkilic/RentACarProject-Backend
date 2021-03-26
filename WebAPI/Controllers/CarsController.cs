using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : Controller
	{
		ICarService _carService;

		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpPost("add")]
		public IActionResult Add(Car car)
		{
			var result =_carService.Add(car);
			return Ok(result);
		}

		[HttpGet("getalldetails")]
		public IActionResult GetAllCarDetails()
		{
			var result = _carService.GetCarDetails();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getcardetailsbybrandid")]
		public IActionResult GetCarDetailsByBrandId(int brandId)
		{
			var result = _carService.GetCarDetailByBrandId(brandId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int carId)
		{
			var result = _carService.GetById(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getcardetailsbycolorid")]
		public IActionResult GetCarDetailsByColorId(int colorId)
		{
			var result = _carService.GetCarDetailByColorId(colorId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
