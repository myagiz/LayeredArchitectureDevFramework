using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DevFramework.Core.CrossCuttingCorners.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate((IValidationContext) entity);

            if (result.Errors.Any())
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
