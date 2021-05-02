using System;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        BookListModel SelectAllBooks();
        BookListModel SelectBooks(RequestBookModel text);
    }

    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookListModel SelectAllBooks()
        {
            BookListModel result = _bookRepository.AllBooks();
            return result;
        }

        public BookListModel SelectBooks(RequestBookModel searchMessage)
        {
            BookListModel result = _bookRepository.QueryBooks(searchMessage);
            return result;
        }
    }
}