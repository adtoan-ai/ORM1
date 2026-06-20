using Microsoft.AspNetCore.Mvc;
using ORM1.Data;
using ORM1.Models;

namespace ORM1.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository repo;

        public BookController(BookRepository repository)
        {
            repo = repository;
        }

        //Danh sách
        public IActionResult Index()
        {
            return View(repo.GetAll());
        }

        //Chi tiết
        public IActionResult Details(int id)
        {
            var book = repo.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        //GET Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(book);
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        //GET Edit
        public IActionResult Edit(int id)
        {
            var book = repo.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.Update(book);
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        //GET Delete
        public IActionResult Delete(int id)
        {
            var book = repo.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}