using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Book.Include(b => b.Author).ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Book.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(BookDTO bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                PublishYear = bookDto.PublishYear,
                AuthorId = bookDto.AuthorId
            };

            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(BookDTO bookDto, int id)
        {
            var bookToUpdate = _context.Book.Find(id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = bookDto.Title;
                bookToUpdate.PublishYear = bookDto.PublishYear;
                bookToUpdate.AuthorId = bookDto.AuthorId;

                _context.Book.Update(bookToUpdate);
                _context.SaveChanges(); 

            }
        }

        public void DeleteBook(int id)
        {
            var book = _context.Book.Find(id);

            if (book != null)
            {
                _context.Book.Remove(book);
                _context.SaveChanges();
            }
        }

    }
}
