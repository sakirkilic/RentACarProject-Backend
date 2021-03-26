using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Abstract;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		//#region Fake Data
		//List<Car> _cars;
		//public InMemoryCarDal()
		//{
		//	_cars = new List<Car> {
		//		new Car{CarId=1, BrandId="bmw", ColorId="kırmızı", DailyPrice=100, Description="spor", ModelYear=2007 },
		//		new Car{CarId=1, BrandId="bmw", ColorId="kırmızı", DailyPrice=100, Description="spor", ModelYear=2007 },
		//		new Car{CarId=5, BrandId="Mercedes", ColorId="kırmızı", DailyPrice=100, Description="spor", ModelYear=2007 },
		//		new Car{CarId=1, BrandId="bmw", ColorId="kırmızı", DailyPrice=100, Description="spor", ModelYear=2007 }
		//	};
		//}
		//#endregion

		//public void Add(Car car)
		//{
		//	_cars.Add(car);
		//}

		//public void Delete(Car car)
		//{
		//	Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
		//	_cars.Remove(carToDelete);
		//}

		//public List<Car> GetAll()
		//{
		//	return _cars;
		//}

		//public Car GetById(int id)
		//{
		//	Car getByIdCar = _cars.SingleOrDefault(c => c.CarId == id);
		//	return getByIdCar;
		//}
		//public void Update (Car car)
		//{
		//	Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
		//	carToUpdate.CarId = car.CarId;
		//	carToUpdate.BrandId = car.BrandId;
		//	carToUpdate.ColorId = car.ColorId;
		//	carToUpdate.ModelYear = car.ModelYear;
		//	carToUpdate.DailyPrice = car.DailyPrice;
		//	carToUpdate.Description = car.Description;

		//}
		public void Add(Car entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Car entity)
		{
			throw new NotImplementedException();
		}

		public Car Get(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public void Update(Car entity)
		{
			throw new NotImplementedException();
		}
	}
}
