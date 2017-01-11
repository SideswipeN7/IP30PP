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
    public class UzytkowniksController : ApiController
    {
        private DB_A16628_OmnibusEntities1 db = new DB_A16628_OmnibusEntities1();

        // GET: api/Uzytkowniks
        public IQueryable<Uzytkownik> GetUzytkownicy()
        {
            return db.Uzytkownicy;
        }


        // GET: api/Uzytkowniks/5
        [ResponseType(typeof(Uzytkownik))]
        public IHttpActionResult GetUzytkownik(int id)
        {
            Uzytkownik uzytkownik = db.Uzytkownicy.Find(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return Ok(uzytkownik);
        }

        // PUT: api/Uzytkowniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUzytkownik(int id, Uzytkownik uzytkownik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uzytkownik.IdUser)
            {
                return BadRequest();
            }

            db.Entry(uzytkownik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UzytkownikExists(id))
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

        // POST: api/Uzytkowniks
        [ResponseType(typeof(Uzytkownik))]
        public IHttpActionResult PostUzytkownik(Uzytkownik uzytkownik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Uzytkownicy.Add(uzytkownik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uzytkownik.IdUser }, uzytkownik);
        }

        // DELETE: api/Uzytkowniks/5
        [ResponseType(typeof(Uzytkownik))]
        public IHttpActionResult DeleteUzytkownik(int id)
        {
            Uzytkownik uzytkownik = db.Uzytkownicy.Find(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            db.Uzytkownicy.Remove(uzytkownik);
            db.SaveChanges();

            return Ok(uzytkownik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UzytkownikExists(int id)
        {
            return db.Uzytkownicy.Count(e => e.IdUser == id) > 0;
        }
    }
}