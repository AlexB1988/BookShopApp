﻿using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class GetBookService:IGetBookService
    {
        public GetBookService()
        {

        }
        public IEnumerable<Book> GetBooks()
        {
            using (var _dataContext = new DataContext())
            {
                var booksTemp = _dataContext.Books.ToList();
                foreach (var book in booksTemp)
                {
                    if (string.IsNullOrWhiteSpace(book.AuthorsList))
                    {
                        var authorByBookId = from author in _dataContext.Authors
                                             join authorsBooks in _dataContext.AuthorsBooks on author.Id equals authorsBooks.AuthorId
                                             join booksFromBase in _dataContext.Books on authorsBooks.BookId equals booksFromBase.Id
                                             where booksFromBase.Id == book.Id
                                             select (author); ;

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
        }

        //public IEnumerable<Domain.Entities.Author> GetAuthorsOfBooks(int bookId)
        //{
        //    using (var _dataContext = new DataContext())
        //    {
        //        var authorsList = from authors in _dataContext.Authors
        //                          join authorsBooks in _dataContext.AuthorsBooks on authors.Id equals authorsBooks.AuthorId
        //                          join books in _dataContext.Books on authorsBooks.BookId equals books.Id
        //                          where books.Id == bookId
        //                          select (authors);
        //        return authorsList;
        //    }
        //}
    }
}
