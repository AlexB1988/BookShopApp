using BookShopApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Validation
{
    public class BookValidator:AbstractValidator<BookValid>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Название книги не может быть пустым");
            RuleFor(x => x.Year).Length(4).WithMessage("Год должен быть четырехзначным числом");
            RuleForEach(x => x.Year).Must(Char.IsDigit).WithMessage("Год должен быть четырехзначным числом");
            RuleFor(x => x.Isbn).Length(17).WithMessage("Поле должно иметь 17 знаков");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Поле кол-во экземпляров не должно быть пустым");
            RuleForEach(x => x.Quantity).Must(Char.IsDigit).WithMessage("Кол-во должно быть положительным числом");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Поле стоимость не может быть пустым");
            RuleFor(x => x.Price).Must(x=>decimal.TryParse(x,out var number)).WithMessage("Некорректная стоимость.\nМежду рублями и копейками\n должна стоять запятая");
            RuleFor(x => x.AuthorListString).NotEmpty().WithMessage("Выберите как минимум одного автора");
        }
    }
}
