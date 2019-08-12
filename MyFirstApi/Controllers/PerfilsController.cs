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
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    public class PerfilsController : ApiController
    {
        private ApiContext db = new ApiContext();

        // GET: api/Perfils
        public IQueryable<Perfil> GetProfiles()
        {
            return db.Profiles;
        }

        // GET: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult GetPerfil(int id)
        {
            Perfil perfil = db.Profiles.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfils/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfil(int id, Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.Id)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfils
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult PostPerfil(Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(perfil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult DeletePerfil(int id)
        {
            Perfil perfil = db.Profiles.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(perfil);
            db.SaveChanges();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int id)
        {
            return db.Profiles.Count(e => e.Id == id) > 0;
        }
    }
}