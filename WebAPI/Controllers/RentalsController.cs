﻿using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentalsController : ControllerBase
	{
		IRentalService _rentalService;

		public RentalsController(IRentalService rentalService)
		{
			_rentalService = rentalService;
		}

		[HttpGet("getallrentaldetails")]
		public IActionResult GetAllRentalDetails()
		{
			var result = _rentalService.GetAllRentalDetails();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}