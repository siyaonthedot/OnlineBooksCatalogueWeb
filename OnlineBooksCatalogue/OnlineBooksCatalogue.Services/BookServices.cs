using OnlineBooksCatalogue.Core.Interfaces;
using OnlineBooksCatalogue.Core.Models;
using OnlineBooksCatalogue.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooksCatalogue.Services
{
    public class BookService : IBookService
    {
        public IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateBook(Book book)
        {
            if (book != null)
            {
                await _unitOfWork.Books.Add(book);
                var result = _unitOfWork.Save();       
                return  result > 0 ? true : false;
            }

            return false;
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            if (bookId > 0)
            {
                var productDetails = await _unitOfWork.Books.GetById(bookId);
                if (productDetails != null)
                {
                    _unitOfWork.Books.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    return result > 0 ? true : false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var productDetailsList = await _unitOfWork.Books.GetAll();
            return productDetailsList;
        }

        public async Task<Book> GetBookById(int bookId)
       {
           return bookId < 1 ? null : await _unitOfWork.Books.GetById(bookId);
    
        }

        public async Task<bool> UpdateBook(Book bookDetail)
        {

            if (bookDetail != null)
            {
                var book = await _unitOfWork.Books.GetById(bookDetail.BookId);
                if (book != null)
                {
                    book.Name = bookDetail.Name;
                    book.Text = bookDetail.Text;
                    book.PurchasePrice = bookDetail.PurchasePrice;

                    _unitOfWork.Books.Update(book);

                    var result = _unitOfWork.Save();

                    return result > 0 ? true : false;
                }
            }
            return false;
        }
    }
}
