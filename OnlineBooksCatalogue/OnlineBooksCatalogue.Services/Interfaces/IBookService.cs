using System;
using System.Collections.Generic;
using System.Text;
using OnlineBooksCatalogue.Core.Models;
using System.Threading.Tasks;

namespace OnlineBooksCatalogue.Services.Interfaces
{
    public interface  IBookService
    {
        Task<bool> CreateBook(Book book);

        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(int bookId);

        Task<bool> UpdateBook(Book book);

        Task<bool> DeleteBook(int bookId);
    }

}
