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
    public class MagazinesController : Controller
    {
        private ApplicationDbContext _context;

        public MagazinesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //-----INDEX------
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMagazines))
                return View("List");

            return View("ReadOnlyList");
        }

        //-------DETAILS--------
        public ActionResult Details(int id)
        {
            var magazine = _context.Magazines.SingleOrDefault(m => m.Id == id);
            if (magazine == null)
                return HttpNotFound();
            return View(magazine);
        }

        //-------------NEW------------
        [Authorize(Roles = RoleName.CanManageMagazines)]
        public ActionResult New()
        {
            var viewModel = new MagazineFormModel();

            return View("MagazineForm", viewModel);
        }

        //-------------EDIT------------
        public ActionResult Edit(int id)
        {
            var magazine = _context.Magazines.SingleOrDefault(m => m.Id == id);
            if (magazine == null)
                return HttpNotFound();

            var viewModel = new MagazineFormModel();
           

            return View("MagazineForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Magazine magazine)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MagazineFormModel();
                return View("MagazineForm", viewModel);

            }

            if (magazine.Id == 0)
            {
                magazine.DateAdded = DateTime.Now;
                _context.Magazines.Add(magazine);
            }
            else
            {
                var magazineInDb = _context.Magazines.Single(m => m.Id == magazine.Id);
                magazineInDb.Title = magazine.Title;
                magazineInDb.desc = magazine.desc;
                magazineInDb.ReleaseDate = magazine.ReleaseDate;
                magazineInDb.NumberInStock = magazine.NumberInStock;
               
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Magazines");
        }

    }
}