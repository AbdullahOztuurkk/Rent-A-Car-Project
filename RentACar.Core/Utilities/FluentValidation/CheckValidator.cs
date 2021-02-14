using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
            var result = validator.Validate(entity);
            if (result.Errors.Count>0)
                throw new ValidationException(result.Errors);
        }
    }
}
