using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using System.Data.Entity;
using Library.ViewModel;


namespace Library.Controllers
{

    public class ReadersController : Controller
    {
        private ApplicationDbContext _context;

        public ReadersController(){
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //-------INDEX------------------
        public ActionResult Index()

        {
           
            return View();
        }

        //-------DETAILS------------------
        public ActionResult Details(int id)
        {
            var reader = _context.Readers.Include(r => r.MembershipType).SingleOrDefault(r => r.Id == id);
            if (reader == null)
                return HttpNotFound();
            return View(reader);
        }

        //-------READERFORM------------------
        public ActionResult ReaderForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new ReaderFormModel
            {
                MembershipTypes = membershipTypes
            };
            return View("ReaderForm" ,viewModel);
        }

        //---------SAVE--------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Reader reader)
        {
            if(reader.Id == 0)

                _context.Readers.Add(reader);
            else
            {
                var readerInDb = _context.Readers.Single(r => r.Id == reader.Id);

                readerInDb.Name = reader.Name;
                readerInDb.Birth = reader.Birth;
                readerInDb.MembershipType = reader.MembershipType;
                readerInDb.IsSubcribe = reader.IsSubcribe;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Readers");
        }

        //------EDIT--------------
        public ActionResult Edit(int id )
        {
            var reader = _context.Readers.SingleOrDefault(r => r.Id == id);
            if (reader == null)
                return HttpNotFound();

            var viewModel = new ReaderFormModel
            {
                Reader = reader,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("ReaderForm", viewModel);
        }
    }
}