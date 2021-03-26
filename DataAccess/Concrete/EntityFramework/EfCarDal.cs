using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			using (ReCapDbContext context = new ReCapDbContext())
			{
				var result = from c in context.Cars
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 select new CarDetailDto
							 {
								 BrandName = b.BrandName,
								 BrandId=c.BrandId,
								 Description = c.Description,
								 DailyPrice = c.DailyPrice,
								 ColorName = co.ColorName,
								 ColorId=c.ColorId,
								 ModelYear=c.ModelYear,
								 CarId=c.Id
								 
							 };

				return filter == null
					? result.ToList()
					: result.Where(filter).ToList();


			}
		}
	}
}
