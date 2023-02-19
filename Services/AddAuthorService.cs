using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class AddAuthorService:IAddAuthorService
    {
        DataContext _dataContext;

        public AddAuthorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool AddAuthor(string name)
        {
            var existsAuthor = _dataContext.Authors.Where(x => x.Name==name);
            if (existsAuthor.Count()>0)
            {
                MessageBox.Show(
                $"Данный автор уже есть в базе\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;

            }

            if (name == "" || name is null || name == " ")
            {
                MessageBox.Show(
                $"Некорректные данные\n" +
                $"Введите имя автора",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else
            {
                var author = new Author
                {
                    Name = name
                };
                _dataContext.Add(author);
                _dataContext.SaveChanges();
                return true;
            }

        }
    }
}
