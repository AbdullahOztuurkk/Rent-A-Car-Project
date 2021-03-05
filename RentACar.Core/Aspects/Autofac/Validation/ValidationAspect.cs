using System;
using System.Linq;
using Castle.DynamicProxy;
using FluentValidation;
using RentACar.Core.Utilities.FluentValidation;
using RentACar.Core.Utilities.Interceptors;

namespace RentACar.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This class didn't implemented from IValidator");
            }

            _validatorType = validatorType;
        }
        /// <summary>
        /// Execute before method
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                CheckValidator.Validate(validator, entity);
            }
        }
    }
}
