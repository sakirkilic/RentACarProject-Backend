using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
	public class RentalDetailDto : IDto
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string CompanyName { get; set; }
		public string BrandName { get; set; }
		public string Description { get; set; }
		public decimal DailyPrice { get; set; }
		public DateTime RentDate { get; set; }
		public DateTime? ReturnDate { get; set; }
	}
}
