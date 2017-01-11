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
    public class WyniksController : ApiController
    {
        private DB_A16628_OmnibusEntities1 db = new DB_A16628_OmnibusEntities1();

        // GET: api/Wyniks
        public IQueryable<Wynik> GetWyniki()
        {
            return db.Wyniki;
        }

        // GET: api/Wyniks/5
        [ResponseType(typeof(Wynik))]
        public IHttpActionResult GetWynik(int id)
        {
            Wynik wynik = db.Wyniki.Find(id);
            if (wynik == null)
            {
                return NotFound();
            }

            return Ok(wynik);
        }

        // PUT: api/Wyniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWynik(int id, Wynik wynik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wynik.IdUser)
            {
                return BadRequest();
            }

            db.Entry(wynik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WynikExists(id))
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

        // POST: api/Wyniks
        [ResponseType(typeof(Wynik))]
        public IHttpActionResult PostWynik(Wynik wynik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wyniki.Add(wynik);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WynikExists(wynik.IdUser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wynik.IdUser }, wynik);
        }

        // DELETE: api/Wyniks/5
        [ResponseType(typeof(Wynik))]
        public IHttpActionResult DeleteWynik(int id)
        {
            Wynik wynik = db.Wyniki.Find(id);
            if (wynik == null)
            {
                return NotFound();
            }

            db.Wyniki.Remove(wynik);
            db.SaveChanges();

            return Ok(wynik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WynikExists(int id)
        {
            return db.Wyniki.Count(e => e.IdUser == id) > 0;
        }
    }
}