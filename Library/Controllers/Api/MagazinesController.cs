using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Library.Models;
using Library.DTOs;
using AutoMapper;

namespace Library.Controllers.Api
{
    public class MagazinesController : ApiController
    {
        private ApplicationDbContext _context;

        public MagazinesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/magazines
        public IEnumerable<MagazineDto> GetMagazines(string query = null)
        {
            var magazinesQuery = _context.Magazines
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                magazinesQuery = magazinesQuery.Where(m => m.Title.Contains(query));

            return magazinesQuery
                .ToList()
                .Select(Mapper.Map<Magazine, MagazineDto>);
        }

        //GET /api/magazine/1
        public IHttpActionResult GetMagazines(int id)
        {
            var magazine = _context.Magazines.SingleOrDefault(b => b.Id == id);

            if (magazine == null)
                return NotFound();

            return Ok(Mapper.Map<Magazine, MagazineDto>(magazine));
        }

        //POST  /api/magazines
        [HttpPost]
        public IHttpActionResult CreateMagazine(MagazineDto magazineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var magazine = Mapper.Map<MagazineDto, Magazine>(magazineDto);

            _context.Magazines.Add(magazine);
            _context.SaveChanges();

            magazineDto.Id = magazine.Id;

            return Created(new Uri(Request.RequestUri + "/" + magazine.Id), magazineDto);
        }

        //PUT /api/magazine/1
        [HttpPut]
        public IHttpActionResult UpdateMagazine(int id, MagazineDto magazineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var magazineInDb = _context.Magazines.SingleOrDefault(b => b.Id == id);


            if (magazineInDb == null)
                return NotFound();


            Mapper.Map(magazineDto, magazineInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/magazines/1
        [HttpDelete]
        public IHttpActionResult DeleteMagazine(int id)
        {
            var magazineInDb = _context.Magazines.SingleOrDefault(b => b.Id == id);

            if (magazineInDb == null)
                return NotFound();

            _context.Magazines.Remove(magazineInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
