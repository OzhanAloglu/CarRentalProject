using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {

        public CarValidator()
        {
            RuleFor(p=>p.Name).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(100).When(p => p.BrandId == 1);
            RuleFor(p=>p.Description).MinimumLength(10);

            //Burada olmayan bir doğrulama kuralı koymak isterseniz.
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("İsim A harfi ile başlamalı");
            
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
