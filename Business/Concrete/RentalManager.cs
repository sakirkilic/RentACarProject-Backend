using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}


		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rental)
		{
			if (rental.ReturnDate != null || _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Count != 0)
			{
				return new ErrorResult(Messages.RentInvalid);
			}
			//IResult result = BusinessRules.Run(IsKoduDeneme(rental));

			//if (result !=null)
			//{
			//	return result;
			//}

			_rentalDal.Add(rental);
			return new SuccessResult(Messages.Rented);
		}

		public IResult Delete(Rental rental)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<Rental>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IDataResult<Rental> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int rentalId)
		{
			
			return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(rentalId));
		}


		[ValidationAspect(typeof(RentalValidator))]
		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult();
		}

		

		public IResult UpdateRenturnDate(int rentalId)
		{
			var updatedReturnDate = _rentalDal.GetAll(r => r.Id == rentalId).LastOrDefault();

			if (updatedReturnDate.ReturnDate != null)
			{
				return new ErrorResult(Messages.ReturnDateNotUpdated);
			}



			updatedReturnDate.ReturnDate = DateTime.Now;
			_rentalDal.Update(updatedReturnDate);
			return new SuccessResult(Messages.ReturnDateUpdated);

		}




		/* Bu iş Kodu düzenlenecek */
		public IResult IsKoduDeneme(Rental rental)
		{
			if (rental.ReturnDate != null || _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Count != 0)
			{
				return new ErrorResult(Messages.RentInvalid);
			}

			return new SuccessResult();
		}

		public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
		{
			return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
		}
	}
}
