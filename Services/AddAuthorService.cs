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
        public AddAuthorService()
        {
        }

        public bool AddAuthor(Author author)
        {
            try
            {
                using (var _dataContext = new DataContext())
                {
                    var existsAuthor = _dataContext.Authors.Where(x => x.Name == author.Name);
                    if (existsAuthor.Count() > 0)
                    {
                        MessageBox.Show(
                        $"Данный автор уже есть в базе\n",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                        return false;

                    }
                    else
                    {
                        _dataContext.Add(author);
                        _dataContext.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                $"{ex.Message}\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }
    }
}
