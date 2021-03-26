using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colordal;
		public ColorManager(IColorDal colorDal)
		{
			_colordal = colorDal;
		}
		[ValidationAspect(typeof(ColorValidator))]
		public IResult Add(Color color)
		{
			_colordal.Add(color);
			return new SuccessResult(Messages.ColorAdded);
		}

		public IResult Delete(Color color)
		{
			_colordal.Delete(color);
			return new SuccessResult(Messages.ColorDeleted);
		}

		public IDataResult<List<Color>> GetAll()
		{
			return new SuccessDataResult<List<Color>>(_colordal.GetAll(),Messages.ColorsListed);
		}

		public IDataResult<Color> GetById(int colorId)
		{
			return new SuccessDataResult<Color>(_colordal.Get(c => c.ColorId == colorId),Messages.ColorGeted);
		}

		[ValidationAspect(typeof(ColorValidator))]
		public IResult Update(Color color)
		{
			_colordal.Update(color);
			return new SuccessResult(Messages.ColorUpdated);
		}
	}
}
