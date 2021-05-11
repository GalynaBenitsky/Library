using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Library.ViewModel;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //-----------INDEX---------------------
        public ActionResult Index()
        {
           
            return View();
        }


        //-----------DETAILS-------------------
        public ActionResult Details(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        //-------------NEW------------
        public ActionResult New()
        {
            var viewModel = new BookFormModel
            {
                Book = new Book()
            };
            

            return View("BookForm", viewModel);
        }

        //-------------EDIT------------
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormModel
            {
                Book = book
            };

            return View("BookForm", viewModel);
        }

        //------------RANDOM--------------------
        public ActionResult Random()
        {
            var book = new Book() { Title = "Dandelion Wine", Author = "Ray Bradbury", Genre = "Novel, Science Fiction, Fantasy Fiction, Fictional Autobiography" };
            var readers = new List<Reader>
            {
                new Reader{Name="Reader 1"},
                new Reader{Name="Reader 2"},

            };

            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Readers = readers
            };

            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new BookFormModel();
                return View("BookForm", viewModel);

            }
            
            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                bookInDb.Title = book.Title;
                bookInDb.Author = book.Author;
                bookInDb.Genre = book.Genre;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDate = book.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }


    }
}