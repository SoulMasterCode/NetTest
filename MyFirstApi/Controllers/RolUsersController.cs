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
    public class RolUsersController : ApiController
    {
        private ApiContext db = new ApiContext();

        // GET: api/RolUsers
        public IQueryable<RolUser> GetRoles()
        {
            return db.Roles;
        }

        // GET: api/RolUsers/5
        [ResponseType(typeof(RolUser))]
        public IHttpActionResult GetRolUser(int id)
        {
            RolUser rolUser = db.Roles.Find(id);
            if (rolUser == null)
            {
                return NotFound();
            }

            return Ok(rolUser);
        }

        // PUT: api/RolUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRolUser(int id, RolUser rolUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rolUser.Id)
            {
                return BadRequest();
            }

            db.Entry(rolUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolUserExists(id))
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

        // POST: api/RolUsers
        [ResponseType(typeof(RolUser))]
        public IHttpActionResult PostRolUser(RolUser rolUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(rolUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rolUser.Id }, rolUser);
        }

        // DELETE: api/RolUsers/5
        [ResponseType(typeof(RolUser))]
        public IHttpActionResult DeleteRolUser(int id)
        {
            RolUser rolUser = db.Roles.Find(id);
            if (rolUser == null)
            {
                return NotFound();
            }

            db.Roles.Remove(rolUser);
            db.SaveChanges();

            return Ok(rolUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolUserExists(int id)
        {
            return db.Roles.Count(e => e.Id == id) > 0;
        }
    }
}