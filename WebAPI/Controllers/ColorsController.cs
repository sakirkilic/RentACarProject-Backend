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
	public class ColorsController : Controller
	{
		IColorService _colorService;

		public ColorsController(IColorService colorService)
		{
			_colorService = colorService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _colorService.GetAll();
			return Ok(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetByID(int id)
		{
			var result = _colorService.GetById(id);
			return Ok(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Color color)
		{
			var result = _colorService.Add(color);

			return Ok(result);
		}
		[HttpPost("delete")]
		public IActionResult Delete (Color color)
		{
			var result = _colorService.Delete(color);
			return Ok(result);
		}


		[HttpPost("update")]
		public IActionResult Update(Color color)
		{
			var result = _colorService.Update(color);
			return Ok(result);
		}
	}
}
