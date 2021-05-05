using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Models;

namespace Library.Controllers.Api
{
    public class ReadersController : ApiController
    {
        private ApplicationDbContext _context;

        public ReadersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/readers
        public IEnumerable<Reader> GetReaders()
        {
            return _context.Readers.ToList();
            
        }

        //GET /api/reader/1
        public Reader GetReader(int id)
        {
            var reader = _context.Readers.SingleOrDefault(r => r.Id == id);

            if(reader == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

                return reader;
        }

        //POST  /api/readers
        [HttpPost]
        public Reader CreateReader(Reader reader)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            _context.Readers.Add(reader);
            _context.SaveChanges();

            return reader;
        }

        [HttpPut]
        public void UpdateReader(int id, Reader reader)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var readerInDb = _context.Readers.SingleOrDefault(r => r.Id == id);


            if (readerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            readerInDb.Name = reader.Name;
            readerInDb.Birth = reader.Birth;
            readerInDb.IsSubcribe = reader.IsSubcribe;
            readerInDb.MembershipTypeId = reader.MembershipTypeId;

            _context.SaveChanges();
        }

         //DELETE /api/readers/1
         [HttpDelete]
        public void DeleteReader(int id)
        {
            var readerInDb = _context.Readers.SingleOrDefault(r => r.Id == id);

            if (readerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Readers.Remove(readerInDb);
            _context.SaveChanges();
        }
    }
}
