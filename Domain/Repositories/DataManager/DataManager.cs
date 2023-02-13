using BookShopApp.Domain.Entities;
using BookShopApp.Domain.Repositories.Interfaces;
using DevExpress.XtraReports.Templates;
using DevExpress.XtraSpreadsheet.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Repositories.DataManager
{

    public class DataManager : IDataManager
    {
        public DataContext _dataContext;

        public DataManager(DataContext dataContext)
        {
            _dataContext=dataContext;
        }
        public IEnumerable<Book> GetBooks()
        {
            var booksTemp = _dataContext.Books.ToList();
            foreach(var book in booksTemp)
            {
                if (book.AuthorsList is null || book.AuthorsList == "")
                {
                    var authorByBookId = GetAuthorsOfBooks(book.Id);

                    string[] authors = new string[authorByBookId.Count()];
                    int i = 0;
                    foreach (var author in authorByBookId)
                    {
                        authors[i] = author.Name;
                        i++;
                    }
                    string stringAuthors = string.Join(", ", authors);
                    book.AuthorsList = stringAuthors;

                }
            }
            _dataContext.SaveChanges();
            var books = _dataContext.Books.Include(x => x.Publisher)
                              .Include(x => x.BookQuantity)
                              .Include(x => x.CurrentPrice)
                              .ToList();
            return books;
        }
        public IEnumerable<Entities.Author> GetAuthors()
        {
            var authors = _dataContext.Authors.ToList();
            return authors;
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            var publishers=_dataContext.Publishers.ToList();
            return publishers;
        }
        public Book GetBookById(int id)
        {
            var book = _dataContext.Books.FirstOrDefault(x=>x.Id==id);
            return book;
        }

        public IEnumerable<Book> GetBooksByAuthor(string name)
        {
            var books = from bookList in _dataContext.Books
                        join authorsBooks in _dataContext.AuthorsBooks on bookList.Id equals authorsBooks.BookId
                        join authors in _dataContext.Authors on authorsBooks.AuthorId equals authors.Id
                        where authors.Name.Contains(name)
                        select(bookList);
            return books;
        }
        public IEnumerable<Entities.Author> GetAuthorsOfBooks(int bookId)
        {
            var authorsList = from authors in _dataContext.Authors
                        join authorsBooks in _dataContext.AuthorsBooks on authors.Id equals authorsBooks.AuthorId
                        join books in _dataContext.Books on authorsBooks.BookId equals books.Id
                        where books.Id==bookId
                        select (authors);
            return authorsList;
        }
        public IEnumerable<Book> GetBooksByPublisher(string name)
        {
            var books = _dataContext.Books.Include(x => x.Publisher).Where(x => x.Publisher.Name.Contains(name));
            return books;
        }
       public IEnumerable<Book> GetBookByName(string name)
        {
            var books = _dataContext.Books.Where(x => x.Name.Contains(name));
            return books;
        }
        public bool AddBook(string name, string year, string isbn, string quantity, string price, string selectedPublisher,List <string> authorList)
        {
            if (price.Contains("."))
            {
                price = price.Replace(".", ",");
            }
            if(name is null || name==""||name==" " ||int.TryParse(year,out var yearResult)==false
                            || int.TryParse(quantity, out var quantityResult) == false 
                            || decimal.TryParse(price, out var priceResult) == false
                            ||selectedPublisher is null || authorList is null)
            {
                MessageBox.Show(
                $"Некорректные данные\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            var publisherBook = _dataContext.Publishers.FirstOrDefault(x => x.Name == selectedPublisher);
            var newBook = new Book
            {
                Name = name,
                Year = int.Parse(year),
                Isbn = isbn,
                PublisherId=publisherBook.Id
            };
            _dataContext.Add(newBook);

            List<AuthorsBooks> authorsBooksList = new List<AuthorsBooks>();
            foreach (var author in authorList)
            {
                var authorToAdd = _dataContext.Authors.FirstOrDefault(x => x.Id == int.Parse(author));
                var authorsBooks = new AuthorsBooks
                {
                    Book = newBook,
                    Author = authorToAdd,
                };
                authorsBooksList.Add(authorsBooks);
            }
            _dataContext.AddRange(authorsBooksList);

            var bookQuantity = new BookQuantity
            {
                Book = newBook,
                Quantity = int.Parse(quantity)
            };
            _dataContext.Add(bookQuantity);

            var currentPrice = new CurrentPrice
            {
                Books = newBook,
                Price = decimal.Parse(price)
            };
            _dataContext.CurrentPrice.Add(currentPrice);

            var bookPrice = new BookPrice
            {
                Books = newBook,
                Price = decimal.Parse(price),
                DateBegin = DateTime.UtcNow
            };
            _dataContext.BookPrice.Add(bookPrice);

            _dataContext.SaveChanges();
            return true;
        }
        public bool AddPublisher(Publisher publisher)
        {
            var existsPublisher = _dataContext.Publishers.FirstOrDefault(x => x.Name == publisher.Name);
            if (existsPublisher == null && publisher is not null)
            {


                if (publisher.Name != "" && publisher.Name is not null)
                {
                    _dataContext.Add(publisher);
                    _dataContext.SaveChanges();
                    return true;
                }
                MessageBox.Show(
                $"Некорректные данные\n" +
                $"Введите наименование издатнльства",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else
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
        }

        public bool AddAuthor(Entities.Author author)
        {
            var existsAuthor = _dataContext.Authors.FirstOrDefault(x => x.Name == author.Name);
            if (existsAuthor != null)
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

            else if (author.Name == "" || author.Name is null)
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
                _dataContext.Add(author);
                _dataContext.SaveChanges();
                return true;
            }

        }

        public bool ChangeBookPrice(Book book, decimal price)
        {
            if (book is not null)
            {
                var oldBookPrice = _dataContext.BookPrice.FirstOrDefault(x => x.BookId == book.Id && x.DateEnd == null);
                if (oldBookPrice is null)
                {
                    return false;
                }
                oldBookPrice.DateEnd = DateTime.UtcNow;
                var newBookPrice = new BookPrice
                {
                    BookId=book.Id,
                    Price = price,
                    DateBegin=DateTime.UtcNow
                };
                _dataContext.Add(newBookPrice);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteBook(Book book)
        {
            if (book is not null)
            {
                //Прописать проверку на наличие продаж по книге 
                //а также на удаление из BookPrice
                var quantityBook = _dataContext.BookQuantities.Where(x => x.BookId == book.Id);
                _dataContext.RemoveRange(quantityBook);
                _dataContext.Books.Remove(book);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaleBook(List<object> list)
        {
            try
            {
                var bookList = GetPurchasedBooks(list);

                var checkList = new CheckList
                {
                    Sum = 0
                };

                _dataContext.CheckList.Add(checkList);

                foreach (var book in bookList)
                {
                    
                    var bookQuantity = _dataContext.BookQuantities.FirstOrDefault(x => x.BookId == book.Id);

                    int quantityToPurchase = book.CountToPurchase;

                    if (bookQuantity.Quantity >= quantityToPurchase)
                    {
                        bookQuantity.Quantity -= quantityToPurchase;

                        var currentPrice = _dataContext.CurrentPrice.FirstOrDefault(x => x.BookId == book.Id);

                        checkList.Sum += (currentPrice.Price * quantityToPurchase);

                        for (int i = 0; i < quantityToPurchase; i++)
                        {
                            var sales = new Sales
                            {
                                PriceId = currentPrice.Id,
                                CheckList = checkList
                            };
                            _dataContext.Sales.Add(sales);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                        $"{book.Name}\n" +
                        $"Кол-ва экземпляров данной \n" +
                        $"книги меньше, чем Вы запросили в чеке.\n" +
                        $"Вернитесь в чек и измените данные.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                        return false;
                    }
                }
                
                _dataContext.SaveChanges();
                MessageBox.Show(
                $"Покупка ена сумму:{checkList.Sum}\n" +
                $"успешно совершена!",
                "Уведомление",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                $"{ex.Message}\n" +
                $"{ex.InnerException}",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }

        public List<Book> GetPurchasedBooks(List<object> list)
        {
            List<Book> selectedBooks = new List<Book>();
            foreach (var book in list)
            {
                selectedBooks.Add(book as Book);
            }
            return selectedBooks;
        }
    }
}
