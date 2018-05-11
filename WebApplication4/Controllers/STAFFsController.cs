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
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class STAFFsController : ApiController
    {
        private ESDprojectEntities db = new ESDprojectEntities();

        // GET: api/STAFFs
        public IQueryable<STAFF> GetSTAFF()
        {
            return db.STAFF;
        }

        // GET: api/STAFFs/5
        [ResponseType(typeof(STAFF))]
        public IHttpActionResult GetSTAFF(int id)
        {
            STAFF sTAFF = db.STAFF.Find(id);
            if (sTAFF == null)
            {
                return NotFound();
            }

            return Ok(sTAFF);
        }

        // PUT: api/STAFFs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTAFF(int id, STAFF sTAFF)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTAFF.Staff_ID)
            {
                return BadRequest();
            }

            db.Entry(sTAFF).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STAFFExists(id))
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

        // POST: api/STAFFs
        [ResponseType(typeof(STAFF))]
        public IHttpActionResult PostSTAFF(STAFF sTAFF)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STAFF.Add(sTAFF);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STAFFExists(sTAFF.Staff_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTAFF.Staff_ID }, sTAFF);
        }

        // DELETE: api/STAFFs/5
        [ResponseType(typeof(STAFF))]
        public IHttpActionResult DeleteSTAFF(int id)
        {
            STAFF sTAFF = db.STAFF.Find(id);
            if (sTAFF == null)
            {
                return NotFound();
            }

            db.STAFF.Remove(sTAFF);
            db.SaveChanges();

            return Ok(sTAFF);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STAFFExists(int id)
        {
            return db.STAFF.Count(e => e.Staff_ID == id) > 0;
        }
    }
}