using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
         public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("AllBooks")]
        public BookListModel GetAllBooks()
        {
            BookListModel result = _bookService.SelectAllBooks();
            return result;
        }

        [HttpGet]
        [Route("QueryBooks")]
        public BookListModel GetBookList(RequestBookModel searchMessage)
        {
            BookListModel result = _bookService.SelectBooks(searchMessage);
            return result;
        }
    }
}