using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libManagmentSystem.Repository
{
    public interface ILibrary
    {

        IEnumerable<Book> ShowBooks();

        Book FetchBookByID(int id);

        bool AddBook(Book book);

        bool UpdateBook(int id, Book updated_values);

        bool RemoveBook(int id);
    }
}
