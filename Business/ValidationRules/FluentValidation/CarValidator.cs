using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.BrandId).NotEmpty();
			RuleFor(c => c.ColorId).NotEmpty();
			RuleFor(c => c.DailyPrice).NotEmpty();
			RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük fiyat 0 ve o sıfırdan küçük olamaz");
			RuleFor(c => c.Description).NotEmpty();
			RuleFor(c => c.Description).MinimumLength(2).WithMessage("Araba ismi minimum iki karakter olmalıdır.");
			RuleFor(c => c.ModelYear).NotEmpty();
		}
	}
}
