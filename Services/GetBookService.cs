using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Domain.Repositories.Interfaces;
using BookShopApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class GetBookService:IGetBookService
    {
        DataContext _dataContext;
        public GetBookService(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public IEnumerable<Book> GetBooks()
        {
            var booksTemp = _dataContext.Books.ToList();
            foreach (var book in booksTemp)
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

        public IEnumerable<Domain.Entities.Author> GetAuthorsOfBooks(int bookId)
        {
            var authorsList = from authors in _dataContext.Authors
                              join authorsBooks in _dataContext.AuthorsBooks on authors.Id equals authorsBooks.AuthorId
                              join books in _dataContext.Books on authorsBooks.BookId equals books.Id
                              where books.Id == bookId
                              select (authors);
            return authorsList;
        }
    }
}
