using System.Collections.Generic;

namespace LibraryAPI
{
    public class BookModel
    {
        public int bookId { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public bool bookmark { get; set; }
        public bool detail { get; set; }
    }

    public class BookListModel
    {
        public List<BookModel> books { get; set; }
    }

    public class RequestBookModel
    {
        public string text { get; set; }
    }
    
}