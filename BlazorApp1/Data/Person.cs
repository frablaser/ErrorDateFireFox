using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BlazorApp1.Data
{
    public class Person
    {
        public string PersonName { get; set; }
        public DateTime? PersonBirthDate { get; set; }

    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(r => r.PersonName).NotEmpty().WithMessage("The name counld not be empty!");
            RuleFor(r => r.PersonBirthDate).Must(BirthDateValidator).WithMessage("Error date!");

        }

        private bool BirthDateValidator(DateTime? date)
        {
            return !(date == null || (date < DateTime.Now.AddYears(-99) || date > DateTime.Now.AddYears(-18)));
        }


    }

}
