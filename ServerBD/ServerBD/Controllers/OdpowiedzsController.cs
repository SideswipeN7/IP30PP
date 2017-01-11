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
    public class OdpowiedzsController : ApiController
    {
        private DB_A16628_OmnibusEntities1 db = new DB_A16628_OmnibusEntities1();

        // GET: api/Odpowiedzs
        public IQueryable<Odpowiedz> GetOdpowiedzi(int i)
        {            
            return db.Odpowiedzi.Where(l => l.IdPytanie == i);
        }

        // GET: api/Odpowiedzs/5
        [ResponseType(typeof(Odpowiedz))]
        public IHttpActionResult GetOdpowiedz(int id)
        {
            Odpowiedz odpowiedz = db.Odpowiedzi.Find(id);
            if (odpowiedz == null)
            {
                return NotFound();
            }

            return Ok(odpowiedz);
        }

        // PUT: api/Odpowiedzs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOdpowiedz(int id, Odpowiedz odpowiedz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != odpowiedz.IdOdpowiedzi)
            {
                return BadRequest();
            }

            db.Entry(odpowiedz).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdpowiedzExists(id))
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

        // POST: api/Odpowiedzs
        [ResponseType(typeof(Odpowiedz))]
        public IHttpActionResult PostOdpowiedz(Odpowiedz odpowiedz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Odpowiedzi.Add(odpowiedz);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = odpowiedz.IdOdpowiedzi }, odpowiedz);
        }

        // DELETE: api/Odpowiedzs/5
        [ResponseType(typeof(Odpowiedz))]
        public IHttpActionResult DeleteOdpowiedz(int id)
        {
            Odpowiedz odpowiedz = db.Odpowiedzi.Find(id);
            if (odpowiedz == null)
            {
                return NotFound();
            }

            db.Odpowiedzi.Remove(odpowiedz);
            db.SaveChanges();

            return Ok(odpowiedz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OdpowiedzExists(int id)
        {
            return db.Odpowiedzi.Count(e => e.IdOdpowiedzi == id) > 0;
        }
    }
}