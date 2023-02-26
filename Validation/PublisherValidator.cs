using BookShopApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Validation
{
    public class PublisherValidator:AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Поле имени издателя не должно быть пустым");
        }
    }
}
