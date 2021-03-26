using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;
		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}


		[CacheAspect]
		[SecuredOperation("admin")]
		[ValidationAspect(typeof(BrandValidator))]
		[CacheRemoveAspect("IBrandService.Get")]
		public IResult Add(Brand brand)
		{


			
			_brandDal.Add(brand);

			return new SuccessResult(Messages.BrandAdded);
		}

		[TransactionScopeAspect]
		public IResult AddTransactionalTest(Brand brand)
		{
			_brandDal.Update(brand);
			_brandDal.Add(brand);
			return new SuccessResult();
		}

		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);

			return new SuccessResult(Messages.BrandDeleted);
		}


		[CacheAspect]
		[PerformanceAspect(1)]   // süreyi aşar ise beni uyarıcak
		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);
		}

		[CacheAspect]
		public IDataResult<Brand> GetById( int brandId)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId),Messages.BrandGeted);

		}


		[ValidationAspect(typeof(BrandValidator))]
		[CacheRemoveAspect("IBrandService.Get")]
		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult(Messages.BrandUpdated);
		}
	}
}
