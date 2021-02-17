using FluentValidation;
using RentACar.Business.Constants;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Validation.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        /// <summary>
        /// Validate car entity with some rules
        /// </summary>
        public CarValidator()
        {
            RuleFor(entity => entity.Description).MinimumLength(2).WithMessage(Messages.Car_Description_Minimum_Length);
            RuleFor(entity => entity.DailyPrice).GreaterThan(0).WithMessage(Messages.Car_DailyPrice_Minimum_Limit);
        }
    }
}
