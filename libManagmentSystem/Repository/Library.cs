using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libManagmentSystem.Repository
{
    public class Library : ILibrary
    {

        lib_management_systemContext b = new lib_management_systemContext();
        public Library(lib_management_systemContext context)
        {
            b = context;
        }
        public IEnumerable<Book> ShowBooks()
        {
            var b_list = from book in b.Book select book;
            return b_list.ToList();
        }

        public Book FetchBookByID(int id)
        {
            var bk = b.Book.Find(id);
            return bk;
        }

        public bool AddBook(Book book)
        {
            if (book.Publication != null && book.BookName != null && book.BookAuthor != null)
            {
                b.Book.Add(book);
                b.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool UpdateBook(int id, Book updated_values)
        {
            Book b1 = b.Book.SingleOrDefault(book => book.BookId == id);
            if (b1 != null)
            {
                b1.BookAuthor = updated_values.BookAuthor;
                b1.BookName = updated_values.BookName;
                b1.Edition = updated_values.Edition;
                b1.Publication = updated_values.Publication;
                b.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveBook(int id)
        {
            var bk = b.Book.SingleOrDefault(book => book.BookId == id);
            if (bk != null)
            {
                b.Remove(bk);
                b.SaveChanges();
                return true;
            }

            return false;

        }



    }
}
