using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Library.Models;
using Library.DTOs;

namespace Library.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

       [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var reader = _context.Readers.Single(
                r => r.Id == newRental.ReaderId);

            var books = _context.Books.Where(
                b => newRental.BookIds.Contains(b.Id)).ToList();

        

            foreach (var book in books) 
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available.");

                book.NumberAvailable--;

                var rental = new Rental
                {
                    Reader = reader,
                    Book = book,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
           

            _context.SaveChanges();

            return Ok();
        }
    }
}