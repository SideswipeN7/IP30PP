using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServerBD.Models;

namespace ServerBD.Controllers
{
    public class PytaniesController : ApiController
    {
        private DB_A16628_OmnibusEntities1 db = new DB_A16628_OmnibusEntities1();

        // GET: api/Pytanies
        public IQueryable<Pytanie> GetPytania()
        {
            return db.Pytania;
        }




        // GET: api/Pytanies/5
        [ResponseType(typeof(Pytanie))]
        public IHttpActionResult GetPytanie(int id)
        {
            Pytanie pytanie = db.Pytania.Find(id);
            if (pytanie == null)
            {
                return NotFound();
            }

            return Ok(pytanie);
        }

        // PUT: api/Pytanies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPytanie(int id, Pytanie pytanie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pytanie.IdPytanie)
            {
                return BadRequest();
            }

            db.Entry(pytanie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PytanieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pytanies
        [ResponseType(typeof(Pytanie))]
        public IHttpActionResult PostPytanie(Pytanie pytanie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pytania.Add(pytanie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pytanie.IdPytanie }, pytanie);
        }

        // DELETE: api/Pytanies/5
        [ResponseType(typeof(Pytanie))]
        public IHttpActionResult DeletePytanie(int id)
        {
            Pytanie pytanie = db.Pytania.Find(id);
            if (pytanie == null)
            {
                return NotFound();
            }

            db.Pytania.Remove(pytanie);
            db.SaveChanges();

            return Ok(pytanie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PytanieExists(int id)
        {
            return db.Pytania.Count(e => e.IdPytanie == id) > 0;
        }
    }
}