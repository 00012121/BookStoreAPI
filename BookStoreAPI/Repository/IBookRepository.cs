using BookStoreAPI.Models;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(int id);
        public void AddBook(BookDTO book);
        public void UpdateBook(BookDTO book, int id);
        public void DeleteBook(int id);
    }
}
