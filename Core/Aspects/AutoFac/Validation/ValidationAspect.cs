using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilites.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.AutoFac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // Bu constracter metot Çağrıldığında verilecek olan metot Ivalidator türündemi diye kontrol eder 
            {
                throw new System.Exception("Bu Bir Doğrulama sınıfı değildir ");
            }
                
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.ValidateOptions(validator, entity);
            }
        }
    }
}
