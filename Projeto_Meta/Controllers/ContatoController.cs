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
using Projeto_Meta.Data;
using Projeto_Meta.Models;

namespace Projeto_Meta.Controllers
{
    public class ContatoController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Contato
        public IQueryable<Contato> GetContatosList(int page = 0, int size = 10)
        {
            return db.Contatos.OrderBy(x => x.id).Skip((page) * size).Take(size);
        }

        // GET: api/Contato/5
        [ResponseType(typeof(Contato))]
        public IHttpActionResult GetContato(int id)
        {
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        // PUT: api/Contato/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContato(int id, Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contato.id)
            {
                return BadRequest();
            }

            db.Entry(contato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
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

        // POST: api/Contato
        [ResponseType(typeof(Contato))]
        public IHttpActionResult PostContato(Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contatos.Add(contato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contato.id }, contato);
        }

        // DELETE: api/Contato/5
        [ResponseType(typeof(Contato))]
        public IHttpActionResult DeleteContato(int id)
        {
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return NotFound();
            }

            db.Contatos.Remove(contato);
            db.SaveChanges();

            return Ok(contato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContatoExists(int id)
        {
            return db.Contatos.Count(e => e.id == id) > 0;
        }
    }
}