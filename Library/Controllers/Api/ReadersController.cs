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
        public IEnumerable<ReaderDto> GetReaders()
        {
            return _context.Readers.ToList().Select(Mapper.Map<Reader, ReaderDto>);
            
        }

        //GET /api/reader/1
        public ReaderDto GetReader(int id)
        {
            var reader = _context.Readers.SingleOrDefault(r => r.Id == id);

            if(reader == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

                return Mapper.Map<Reader,ReaderDto>(reader) ;
        }

        //POST  /api/readers
        [HttpPost]
        public ReaderDto CreateReader(ReaderDto readerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reader = Mapper.Map<ReaderDto, Reader>(readerDto);

            _context.Readers.Add(reader);
            _context.SaveChanges();

            readerDto.Id = reader.Id;

            return readerDto;
        }

        //PUT /api/reader/1
        [HttpPut]
        public void UpdateReader(int id, ReaderDto readerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var readerInDb = _context.Readers.SingleOrDefault(r => r.Id == id);


            if (readerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(readerDto, readerInDb);

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
