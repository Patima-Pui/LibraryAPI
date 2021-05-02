using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryAPI.Repositories
{
    public interface IBookRepository
    {
        BookListModel AllBooks();
        BookListModel QueryBooks(RequestBookModel inputSearch);
    }

    public class BookRepository : IBookRepository
    {

        public BookListModel AllBooks()
        {
            var cs = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
            using var con = new SqlConnection(cs); //Using Class SqlConnection for COnnent to database
            con.Open();

            string sql = "SELECT Id, Name, Auther, Category, Bookmark, Detail FROM BookTable";

            using var cmd = new SqlCommand(sql, con);
            
            using SqlDataReader rdr = cmd.ExecuteReader();

            BookListModel output = new BookListModel();
            output.books = new List<BookModel>();

            while (rdr.Read())
            {
                output.books.Add(
                    new BookModel()
                    {
                        bookId = rdr.GetInt32(0),
                        name = rdr.GetString(1),
                        author = rdr.GetString(2),
                        category = rdr.GetString(3),
                        bookmark = rdr.GetBoolean(4),
                        detail = rdr.GetBoolean(5),
                    }
                );
            }
            return output;
        }

        public BookListModel QueryBooks(RequestBookModel searchMessage)
        {
            var cs = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
            using var con = new SqlConnection(cs); //Using Class SqlConnection for COnnent to database
            con.Open();

            string sql = string.Format(@"SELECT Id, Name, Auther, Category, BookmarkBtn, DetailBtn FROM BookTable 
                                        WHERE(Name LIKE '%{0}%' OR Auther LIKE '%{0}%' OR Category LIKE '%{0}%')",
                                        searchMessage.text);

            using var cmd = new SqlCommand(sql, con);
            
            using SqlDataReader rdr = cmd.ExecuteReader();

            BookListModel output = new BookListModel();
            output.books = new List<BookModel>();

            while (rdr.Read())
            {
                output.books.Add(
                    new BookModel()
                    {
                        bookId = rdr.GetInt32(0),
                        name = rdr.GetString(1),
                        author = rdr.GetString(2),
                        category = rdr.GetString(3),
                        bookmark = rdr.GetBoolean(4),
                        detail = rdr.GetBoolean(5),
                    }
                );
            }
            return output;
        }
    }
}