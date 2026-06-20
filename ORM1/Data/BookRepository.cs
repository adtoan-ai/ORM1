using ORM1.Models;

namespace ORM1.Data
{
    public class BookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.Find(id);
        }

        public void Insert(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Update(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = context.Books.Find(id);

            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }
    }
}