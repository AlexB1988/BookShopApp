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

        public bool AddPublisher(Publisher publisher)
        {
            try
            {
                using (var _dataContext = new DataContext())
                {
                    var existsPublisher = _dataContext.Publishers.Where(x => x.Name == publisher.Name);
                    if (existsPublisher.Count() > 0)
                    {
                        MessageBox.Show(
                        $"Данный издатель уже есть в базе\n",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                        return false;

                    }
                    else
                    {
                        _dataContext.Add(publisher);
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
