using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarImageService
	{
        IDataResult<List<CarImage>> GetImagesByCarId(int id);

        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> Get(int id);

        IResult Add(IFormFile file, CarImage carImage);

        IResult Delete(CarImage carImage);

        IResult Update(IFormFile file, CarImage carImage);

    }
}
