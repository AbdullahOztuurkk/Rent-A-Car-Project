using FluentValidation;

namespace RentACar.Core.Utilities.FluentValidation
{
    public static  class CheckValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="entity"></param>
        public static void Validate(IValidator validator, object entity)
        {
            var context=new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (result.Errors.Count>0)
                throw new ValidationException(result.Errors);
        }
    }
}
