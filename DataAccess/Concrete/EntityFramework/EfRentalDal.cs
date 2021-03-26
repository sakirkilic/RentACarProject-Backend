using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
	{
		public List<RentalDetailDto> GetAllRentalDetails()
		{
			using (ReCapDbContext context = new ReCapDbContext())
			{
				var result = from r in context.Rentals
							 join c in context.Customers
							 on r.CustomerId equals c.Id
							 join ca in context.Cars
							 on r.CarId equals ca.Id
							 join b in context.Brands
							 on ca.BrandId equals b.BrandId
							 join u in context.Users
							 on c.UserId equals u.Id
							 select new RentalDetailDto
							 {
								 FullName = u.FirstName + " " + u.LastName,
								 Email = u.Email,
								 CompanyName = c.CompanyName,
								 BrandName = b.BrandName,
								 Description = ca.Description,
								 DailyPrice = ca.DailyPrice,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate
							 };


				return result.ToList();
			}

		}

		public List<RentalDetailDto> GetRentalDetails(int rentalId)
		{
			using (ReCapDbContext context = new ReCapDbContext())
			{
				var result = from r in context.Rentals
							 join c in context.Customers
							 on r.CustomerId equals c.Id
							 join ca in context.Cars
							 on r.CarId equals ca.Id
							 join b in context.Brands
							 on ca.BrandId equals b.BrandId
							 join u in context.Users
							 on c.UserId equals u.Id
							 where r.Id==rentalId
							 select new RentalDetailDto
							 {
								 FullName = u.FirstName+" "+u.LastName,
								 Email = u.Email,
								 CompanyName = c.CompanyName,
								 BrandName = b.BrandName,
								 Description = ca.Description,
								 DailyPrice = ca.DailyPrice,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate
							 };


				return result.ToList();
			}


		}
	}
}
