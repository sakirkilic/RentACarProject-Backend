using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;

		public CarImageManager(ICarImageDal carImageDal)
		{
			_carImageDal = carImageDal;
		}

		public IResult Add(IFormFile file, CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));


			if (result != null)
			{
				return new ErrorResult();
			}
			carImage.Date = DateTime.Now;
			carImage.ImagePath = FileHelper.Add(file);
			_carImageDal.Add(carImage);
			return new SuccessResult();

		}

		// Arabanın resimlerinin tamamlanıp tamamlanmadığını ölçen method (max 5 resim):
		private IResult CheckImageLimitExceeded(int carid)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carid).Count;
			if (result >= 5)
			{
				return new ErrorResult(Messages.CarImageLimitExceeded);
			}
			return new SuccessResult();
		}

		public IResult Delete(CarImage carImage)
		{

			var result = this.Get(carImage.Id);
			var Deleted = FileHelper.Delete(result.Data.ImagePath);
			if (Deleted.Success)
			{
				_carImageDal.Delete(carImage);
				return new SuccessResult();
			}
			return new ErrorResult();
		}


		public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
		{
			return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
		}

		// Arabanın herhangi bir resmi yoksa default resmimizi gönderen method:
		private List<CarImage> CheckIfCarImageNull(int carId)
		{
			var result = _carImageDal.GetAll(i => i.CarId == carId).Any();
			if (!result)
			{
				return new List<CarImage>
				{
					new CarImage
					{
						CarId = carId,
						Date= DateTime.Now,
						ImagePath =  Environment.CurrentDirectory + @"\wwwroot\Images\download.jpg"
					}
				};
			}
			return _carImageDal.GetAll(i => i.CarId == carId);
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		public IResult Update(IFormFile file, CarImage carImage)
		{
			carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);

			_carImageDal.Update(carImage);

			return new SuccessResult();
		}

		public IDataResult<CarImage> Get(int id)
		{

			return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id));
		}



	}
}
