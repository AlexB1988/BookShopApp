using BookShopApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Validation
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Поле имени автора не должно быть пустым");
        }
    }
}
