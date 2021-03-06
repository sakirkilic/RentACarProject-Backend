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
	public class EfCustomerDal : EfEntityRepositoryBase<Customer,ReCapDbContext> , ICustomerDal
	{
		public List<CustomerDetailDto> GetAllCustomerDetails()
		{

			using (ReCapDbContext context = new ReCapDbContext())
			{
				var result = from c in context.Customers
							 join u in context.Users
							 on c.UserId equals u.Id
							 select new CustomerDetailDto
							 {
								 FirstName = u.FirstName,
								 LastName = u.LastName,
								 Email = u.Email,
								 CompanyName = c.CompanyName
							 };
				return result.ToList();
			}
			
		}
	}
}
