using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Aracın günlük kira bedeli 0 dan büyük olmalıdır.");
        }
    }
}
