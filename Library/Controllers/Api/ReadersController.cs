using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Models;
using Library.DTOs;
using AutoMapper;

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
        public IHttpActionResult GetReaders()
        {
            var readerDto = _context.Readers.ToList().Select(Mapper.Map<Reader, ReaderDto>);
            return Ok(readerDto);

        }

        //GET /api/readers/1
        public IHttpActionResult GetReaders(int id)
        {
            var reader = _context.Readers.SingleOrDefault(b => b.Id == id);

            if (reader == null)
                return NotFound();

            return Ok(Mapper.Map<Reader, ReaderDto>(reader));
        }

        //POST  /api/readers
        [HttpPost]
        public IHttpActionResult CreateReader(ReaderDto readerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var reader = Mapper.Map<ReaderDto, Reader>(readerDto);

            _context.Readers.Add(reader);
            _context.SaveChanges();

            readerDto.Id = reader.Id;

            return Created(new Uri(Request.RequestUri + "/" + reader.Id), readerDto);
        }

        //PUT /api/reader/1
        [HttpPut]
        public IHttpActionResult UpdateReader(int id, ReaderDto readerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var readerInDb = _context.Readers.SingleOrDefault(b => b.Id == id);


            if (readerInDb == null)
                return NotFound();


            Mapper.Map(readerDto, readerInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/readers/1
        [HttpDelete]
        public IHttpActionResult DeleteReader(int id)
        {
            var readerInDb = _context.Readers.SingleOrDefault(b => b.Id == id);

            if (readerInDb == null)
                return NotFound();

            _context.Readers.Remove(readerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
