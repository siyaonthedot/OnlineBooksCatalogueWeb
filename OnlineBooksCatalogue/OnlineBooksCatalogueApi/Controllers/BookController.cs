using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBooksCatalogue.Core.Models;
using OnlineBooksCatalogue.Services.Interfaces;
using OnlineBooksCatalogueApi.ViewModels;
using System.Threading.Tasks;

namespace OnlineBooksCatalogueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;
        private readonly IMapper _mapper;
  
        public BookController(IBookService bookService, IMapper mapper)
        {
            this._bookService = bookService;
            this._mapper = mapper;       
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var bookDetailsList = await _bookService.GetAllBooks();

            return bookDetailsList == null ? NotFound() : Ok(bookDetailsList);
        }

        [HttpGet("{bookId}", Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var bookDetails = await _bookService.GetBookById(bookId);

            return bookDetails == null ? NotFound() : Ok(bookDetails);
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook(BookModel model)
        {
            var bookDetails = _mapper.Map<Book>(model);
            var isBookCreated = await _bookService.CreateBook(bookDetails);
            
            return isBookCreated == true ?
                    Ok(isBookCreated) : isBookCreated == false ? 
                     BadRequest() : BadRequest();
        }

        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook(BookModel model)
        {
            var bookDetails = _mapper.Map<Book>(model);  
            var isBookCreated = await _bookService.UpdateBook(bookDetails);

                return isBookCreated == true ? Ok(isBookCreated) :
                       isBookCreated == false ? BadRequest() :
                                               BadRequest();             
        }


        [HttpDelete("{bookId}", Name = "DeleteBook")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var isBookDeleted = await _bookService.DeleteBook(bookId);

            return isBookDeleted == true ? Ok(isBookDeleted) :
                   isBookDeleted == false ? BadRequest() : BadRequest();
          
        }


    }
}
