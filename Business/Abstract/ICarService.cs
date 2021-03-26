using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();

		IDataResult<List<Car>> GetCarsByBrandId(int brandId); 
		IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId); 
		IDataResult<List<Car>> GetCarsByColorId(int colorId);
		IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int colorId);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IDataResult<Car> GetById(int id);
		IResult Add(Car car);
		IResult Delete(Car car);
		IResult Update(Car car);

	}
}
