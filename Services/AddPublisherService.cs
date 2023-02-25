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
    public class AddPublisherService:IAddPublisherService
    {
        public AddPublisherService()
        {
        }

        public bool AddPublisher(string name)
        {
            using (var _dataContext = new DataContext())
            {

                var existsPublisher = _dataContext.Authors.Where(x => x.Name == name);
                if (existsPublisher.Count() > 0)
                {
                    MessageBox.Show(
                    $"Данный издатель уже есть в базе\n",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    return false;

                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show(
                    $"Некорректные данные\n" +
                    $"Введите имя издателя",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    return false;
                }
                else
                {
                    var publisher = new Publisher
                    {
                        Name = name
                    };
                    _dataContext.Add(publisher);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
        }
    }
}
